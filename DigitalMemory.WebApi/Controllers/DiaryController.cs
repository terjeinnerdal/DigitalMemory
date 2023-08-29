using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMemory.WebApi.Data;
using DigitalMemory.Models;
using DigitalMemory.WebApi.Dtos;
using AutoMapper;

namespace DigitalMemory.WebApi.Controllers
{
    // TODO: Need to make sure only owner can GET, POST, PUT, PATCH and DELETE their diaries.
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly DigitalMemoryWebApiContext _context;
        private readonly IMapper _mapper;

        public DiaryController(DigitalMemoryWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Diary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaryDto>>> GetDiaries()
        {
            if (_context.Diaries == null)
            {
                return NotFound();
            }

            var diaries = await _context.Diaries.ToListAsync();

            var diaryDtos = _mapper.Map<IEnumerable<DiaryDto>>(diaries);
            return diaryDtos.ToList<DiaryDto>();
        }


        // GET: api/Diary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryDto>> GetDiary(Guid id)
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

            await _context.Entry(diary).Collection<Entry>(e => e.Entries).LoadAsync();
            return _mapper.Map<DiaryDto>(diary);
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
        public async Task<ActionResult<Diary>> PostDiary(DiaryDto diaryDto)
        {
            if (_context.Diaries == null)
            {
                return Problem("Entity set 'DigitalMemoryWebApiContext.Diary'  is null.");
            }
            var diary = _mapper.Map<Diary>(diaryDto);
            await _context.Diaries.AddAsync(diary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiary", new { id = diaryDto.Id }, diaryDto);
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

            await _context.Entry(diary).Collection<Entry>("Entries").LoadAsync();
            _context.Diaries.Remove(diary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaryExists(Guid id)
        {
            return (_context.Diaries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
