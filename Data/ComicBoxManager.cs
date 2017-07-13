using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        private static void ApplyStateUsingIsKeySet(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public List<Title> GetTitleReferenceList()
        {
            var titles = _context.titles
                 .Include(title => title.Tags)
                 .ToList();

            return titles;
        }

        public async Task<Title> GetTitleData(int id)
        {
            var title = await _context.titles
                .Include(t => t.Tags)
                .Include(t => t.Issues)
                .SingleOrDefaultAsync(t => t.TitleId == id);

            return title;
        }

        public void SaveTitle(Title title)
        {
            _context.ChangeTracker
                .TrackGraph(title, e => ApplyStateUsingIsKeySet(e.Entry));
            _context.SaveChanges();
        }

        public bool TitleExists(int id)
        {
            return _context.titles.Any(e => e.TitleId == id);
        }

    }
}
