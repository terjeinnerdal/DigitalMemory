using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
using DigitalMemory.WebApi.Dtos;
using AutoMapper;
using DigitalMemory.WebApi.Models;

namespace DigitalMemory.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly DigitalMemoryWebApiContext _context;
    private readonly IMapper _mapper;

    public PersonController(DigitalMemoryWebApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Person
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetDiaries()
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var diaries = await _context.Diaries.ToListAsync();
        
        return Ok(_mapper.Map<IEnumerable<PersonDto>>(diaries));
    }

    // GET: api/Person/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetPerson(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        
        // await _context.Entry(person).Collection<Entry>(p => p.Entries).LoadAsync();
        return _mapper.Map<PersonDto>(person);
    }

    // PUT: api/Person/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerson(Guid id, PersonDto personDto)
    {
        if (id != personDto.Id)
        {
            return BadRequest();
        }

        var person = _mapper.Map<Person>(personDto);
        _context.Entry(person).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(id))
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

    // POST: api/PersonDto
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PersonDto>> PostPerson(PersonDto personDto)
    {
        if (_context.Diaries == null)
        {
            return Problem("Entity set 'DigitalMemoryWebApiContext.Persons' is null.");
        }
        var person = _mapper.Map<Person>(personDto);
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        var newPersonDto = _mapper.Map<PersonDto>(person);
        return CreatedAtAction("GetPerson", new { id = personDto.Id }, newPersonDto);
    }

    // DELETE: api/Person/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var Person = await _context.Diaries.FindAsync(id);
        if (Person == null)
        {
            return NotFound();
        }

        await _context.Entry(Person).Collection<Entry>("Entries").LoadAsync();
        _context.Diaries.Remove(Person);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonExists(Guid id)
    {
        return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
