using System;
using System.Collections.Generic;
using System.Collections;
using ComicBox.Data;

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
        public ICollection<Tag> Tags { get; set; }

    }

}