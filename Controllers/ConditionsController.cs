using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBox.Data;
using ComicBox.Models;

namespace ComicBox.Controllers
{
    [Produces("application/json")]
    [Route("api/Conditions")]
    public class ConditionsController : Controller
    {
        private readonly ComicBoxContext _context;

        public ConditionsController(ComicBoxContext context)
        {
            _context = context;
        }

        // GET: api/Conditions
        [HttpGet]
        public IEnumerable<Tag> Getconditions()
        {
            return _context.conditions.Select(g => new Tag { TagId = g.TagId, Label = g.Label }); ;
        }

        // GET: api/Conditions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condition = await _context.conditions
                .Include(c => c.ConditionBooks)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(t => t.Title)
                .SingleOrDefaultAsync(m => m.TagId == id);

            if (condition == null)
            {
                return NotFound();
            }

            return Ok(condition);
        }

        // PUT: api/Conditions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition([FromRoute] int id, [FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condition.TagId)
            {
                return BadRequest();
            }

            _context.Entry(condition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionExists(id))
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

        // POST: api/Conditions
        [HttpPost]
        public async Task<IActionResult> PostCondition([FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.conditions.Add(condition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondition", new { id = condition.TagId }, condition);
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condition = await _context.conditions.SingleOrDefaultAsync(m => m.TagId == id);
            if (condition == null)
            {
                return NotFound();
            }

            _context.conditions.Remove(condition);
            await _context.SaveChangesAsync();

            return Ok(condition);
        }

        private bool ConditionExists(int id)
        {
            return _context.conditions.Any(e => e.TagId == id);
        }
    }
}