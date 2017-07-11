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
    [Route("api/Issues")]
    public class IssuesController : Controller
    {
        private readonly ComicBoxContext _context;

        public IssuesController(ComicBoxContext context)
        {
            _context = context;
        }

        // GET: api/Issue
        [HttpGet]
        public IEnumerable<Issue> Getissues()
        {
            return _context.issues;
        }

        // GET: api/Issue/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var issue = await _context.issues.SingleOrDefaultAsync(m => m.IssueId == id);

            if (issue == null)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        // PUT: api/Issue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue([FromRoute] int id, [FromBody] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issue.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        // POST: api/Issue
        [HttpPost]
        public async Task<IActionResult> PostIssue([FromBody] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.issues.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssue", new { id = issue.IssueId }, issue);
        }

        // DELETE: api/Issue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var issue = await _context.issues.SingleOrDefaultAsync(m => m.IssueId == id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.issues.Remove(issue);
            await _context.SaveChangesAsync();

            return Ok(issue);
        }

        private bool IssueExists(int id)
        {
            return _context.issues.Any(e => e.IssueId == id);
        }
    }
}