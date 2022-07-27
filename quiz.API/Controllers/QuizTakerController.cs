using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz.API.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizTakerController : ControllerBase
    {
        private readonly MusicQuizDbContext _context;

        public QuizTakerController(MusicQuizDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizTaker>>> GetQuizTakers()
        {
            return await _context.QuizTakers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizTaker>> GetQuizTaker(int id)
        {
            var QuizTaker = await _context.QuizTakers.FindAsync(id);

            if (QuizTaker == null)
            {
                return NotFound();
            }

            return QuizTaker;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizTaker(int id, QuizTakerResult _quizTakerResult)
        {
            if (id != _quizTakerResult.QuizTakerId)
            {
                return BadRequest();
            }

            QuizTaker QuizTaker = _context.QuizTakers.Find(id);
            QuizTaker.Score = _quizTakerResult.Score;

            _context.Entry(QuizTaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizTakerExists(id))
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

        [HttpPost]
        public async Task<ActionResult<QuizTaker>> PostQuizTaker(QuizTaker QuizTaker)
        {
            var temp = _context.QuizTakers
                .Where(x => x.Name == QuizTaker.Name
                && x.Email == QuizTaker.Email)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.QuizTakers.Add(QuizTaker);
                await _context.SaveChangesAsync();
            }
            else
                QuizTaker = temp;

            return Ok(QuizTaker);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizTaker(int id)
        {
            var QuizTaker = await _context.QuizTakers.FindAsync(id);
            if (QuizTaker == null)
            {
                return NotFound();
            }

            _context.QuizTakers.Remove(QuizTaker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizTakerExists(int id)
        {
            return _context.QuizTakers.Any(e => e.QuizTakerId == id);
        }
    }
}