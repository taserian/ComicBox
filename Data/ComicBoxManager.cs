using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComicBox.Models;
using Newtonsoft.Json;

namespace ComicBox.Data
{
    public class ComicBoxManager
    {
        private ComicBoxContext _context;

        public ComicBoxManager(ComicBoxContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<TitleShort>> GetTitleReferenceList()
        {
            var titles = await _context.titles
                .Include(t => t.Tags)
                    .ThenInclude(c => c.Tag)
                .OrderBy(t => t.SeriesTitle)
                .Select(i => i.ToShortData())
                .ToListAsync();

            return titles;
        }

        public async Task<Title> GetTitleData(int id)
        {
            var title = await _context.titles
                .Include(t => t.Tags)
                    .ThenInclude(c => c.Tag)
                .Include(t => t.Issues)
                .SingleOrDefaultAsync(t => t.TitleId == id);

            return title;
        }

        //public async Task<IActionResult> SaveTitle(int id, Title title)
        //{

        //}

    }
}
