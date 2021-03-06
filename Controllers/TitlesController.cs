using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBox.Data;
using ComicBox.Models;
using Newtonsoft.Json;

namespace ComicBox.Controllers
{
    [Produces("application/json")]
    [Route("api/Titles")]
    public class TitlesController : Controller
    {
        private readonly ComicBoxManager _repo;

        public TitlesController(ComicBoxManager repo)
        {
            _repo = repo;
        }

        // GET: api/Titles
        [HttpGet]
        public List<Title> Gettitles()
        {
            return _repo.GetTitleReferenceList();
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var title = await _repo.GetTitleData(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/Titles/5
        [HttpPut("{id}")]
        public IActionResult PutTitle([FromRoute] int id, [FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.TitleId)
            {
                return BadRequest();
            }

            try
            {
                _repo.SaveTitle(title);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        // POST: api/Titles
        [HttpPost]
        public IActionResult PostTitle([FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.SaveTitle(title);

            return CreatedAtAction("GetTitle", new { id = title.TitleId }, title);
        }

        //// DELETE: api/Titles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var title = await _context.titles.SingleOrDefaultAsync(m => m.TitleId == id);
        //    if (title == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.titles.Remove(title);
        //    await _context.SaveChangesAsync();

        //    return Ok(title);
        //}

        private bool TitleExists(int id)
        {
            return _repo.TitleExists(id);
        }
    }
}