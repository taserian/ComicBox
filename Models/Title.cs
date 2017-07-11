using System;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Comic Title, as in "Amazing Spider-Man". GCD refers to it as Series.
/// </summary>
namespace ComicBox.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public String Publisher { get; set; }
        public String SeriesTitle { get; set; }
        public int GcdSeriesId { get; set; }

        public ICollection<Issue> Issues { get; set; }
        public ICollection<TitleTag> Tags { get; set; }

        public TitleShort ToShortData()
        {
            return new TitleShort(this);
        }
    }

    public class TitleShort
    {
        public int TitleId { get; set; }
        public string SeriesTitle { get; set; }
        public List<ItemTagShort> Tags { get; set; }

        public TitleShort(Title t)
        {
            this.Tags = new List<ItemTagShort>();

            this.TitleId = t.TitleId;
            this.SeriesTitle = t.SeriesTitle;
            foreach (var g in t.Tags)
            {
                this.Tags.Add(g.Tag.ToShortData());
            }
        }
    }
}