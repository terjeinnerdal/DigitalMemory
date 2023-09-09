using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
using DigitalMemory.WebApi.Dtos;
using AutoMapper;
using DigitalMemory.WebApi.Models;

// todo: Need to make sure only owner can GET, POST, PUT, and DELETE their diaries.
namespace DigitalMemory.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EntryController : ControllerBase
{
    private readonly DigitalMemoryWebApiContext _context;
    private readonly IMapper _mapper;

    public EntryController(DigitalMemoryWebApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Entry
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EntryDto>>> GetEntries()
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var entries = await _context.Entries.ToListAsync();
        
        return Ok(_mapper.Map<IEnumerable<EntryDto>>(entries));
    }

    // GET: api/Entry/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EntryDto>> GetEntry(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var entry = await _context.Entries.FindAsync(id);
        if (entry == null)
        {
            return NotFound();
        }
        
        await _context.Entry(entry).Collection(e => e.Locations).LoadAsync();
        await _context.Entry(entry).Collection(e => e.Pictures).LoadAsync();
        await _context.Entry(entry).Collection(e => e.Events).LoadAsync();
        await _context.Entry(entry).Collection(e => e.Persons).LoadAsync();
        return _mapper.Map<EntryDto>(entry);
    }

    // PUT: api/Entry/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEntry(Guid id, EntryDto entry)
    {
        if (id != entry.Id)
        {
            return BadRequest();
        }

        _context.Entry(_mapper.Map<Entry>(entry)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Entry
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EntryDto>> PostEntry(EntryDto entryDto)
    {
        if (_context.Diaries == null)
        {
            return Problem("Entity set 'DigitalMemoryWebApiContext.Entry'  is null.");
        }

        var entry = _mapper.Map<Entry>(entryDto);

        await _context.Entries.AddAsync(entry);
        await _context.SaveChangesAsync();
        entryDto = _mapper.Map<EntryDto>(entry);

        return CreatedAtAction("GetEntry", new { id = entryDto.Id }, entryDto);
    }

    // DELETE: api/Entry/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEntry(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var entry = await _context.Entries.FindAsync(id);
        if (entry == null)
        {
            return NotFound();
        }

        _context.Entries.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EntryExists(Guid id)
    {
        return (_context.Diaries?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
