using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
using DigitalMemory.WebApi.Models;

namespace DigitalMemory.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiaryController(DigitalMemoryWebApiContext context) : ControllerBase
{
    private readonly DigitalMemoryWebApiContext _context = context;

    // GET: api/Diary
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Diary>>> GetDiaries()
    {
        // TODO: Need to make sure only owner can read their diaries.
        if (_context.Diaries == null)
        {
            return NotFound();
        }
        var diaries = await _context.Diaries.ToListAsync();
        
        return diaries;
    }

    // GET: api/Diary/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Diary?>> GetDiary(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var diary = await _context.Diaries.FindAsync(id);
        if (diary == null)
        {
            return NotFound();
        }
        
        await _context.Entry(diary).Collection<Entry>("Entries").LoadAsync();

        return diary;
    }

    // PUT: api/Diary/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDiary(Guid id, Diary diary)
    {
        if (id != diary.Id)
        {
            return BadRequest();
        }

        _context.Entry(diary).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DiaryExists(id))
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

    // POST: api/Diary
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Diary>> PostDiary(Diary diary)
    {
        if (_context.Diaries == null)
        {
            return Problem("Entity set 'DigitalMemoryWebApiContext.Diary'  is null.");
        }

        await _context.Diaries.AddAsync(diary);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDiary", new { id = diary.Id }, diary);
    }

    // DELETE: api/Diary/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiary(Guid id)
    {
        if (_context.Diaries == null)
        {
            return NotFound();
        }

        var diary = await _context.Diaries.FindAsync(id);
        if (diary == null)
        {
            return NotFound();
        }

        _context.Diaries.Remove(diary);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DiaryExists(Guid id)
    {
        return (_context.Diaries?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
