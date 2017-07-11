using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBox.Data;
using ComicBox.Models;
using System.Collections;

namespace ComicBox.Controllers
{
    [Produces("application/json")]
    [Route("api/ItemTags")]
    public class ItemTagsController : Controller
    {
        private readonly ComicBoxContext _context;

        public ItemTagsController(ComicBoxContext context)
        {
            _context = context;
        }

        // GET: api/ItemTags
        [HttpGet]
        public IEnumerable<Tag> Gettags()
        {
            return _context.tags.Select(g => new Tag { TagId = g.TagId, Label = g.Label});
        }

        // GET: api/ItemTags/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemTag([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemTag = await _context.tags
                .Include(t => t.TaggedTitles)
                    .ThenInclude(t => t.Title)
                .Include(i => i.TaggedIssues)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(t => t.Title)
                .Include(b => b.TaggedBooks)
                    .ThenInclude(b => b.Book)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(t => t.Title)
                .SingleOrDefaultAsync(m => m.TagId == id)
;

            if (itemTag == null)
            {
                return NotFound();
            }

            return Ok(itemTag);
        }

        // PUT: api/ItemTags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemTag([FromRoute] int id, [FromBody] ItemTag itemTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemTag.TagId)
            {
                return BadRequest();
            }

            _context.Entry(itemTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTagExists(id))
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

        // POST: api/ItemTags
        [HttpPost]
        public async Task<IActionResult> PostItemTag([FromBody] ItemTag itemTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tags.Add(itemTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemTag", new { id = itemTag.TagId }, itemTag);
        }

        // DELETE: api/ItemTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemTag([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemTag = await _context.tags.SingleOrDefaultAsync(m => m.TagId == id);
            if (itemTag == null)
            {
                return NotFound();
            }

            _context.tags.Remove(itemTag);
            await _context.SaveChangesAsync();

            return Ok(itemTag);
        }

        private bool ItemTagExists(int id)
        {
            return _context.tags.Any(e => e.TagId == id);
        }
    }
}