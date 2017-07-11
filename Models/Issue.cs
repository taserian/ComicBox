using System;
using System.Collections.Generic;

/// <summary>
/// Comic Book Issue, as in "Iron Man #1".
/// Not the same as a physical book.
/// </summary>
namespace ComicBox.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public int IssueNumber { get; set; }
        public DateTime? IssueReleaseDate { get; set; }
        public Decimal? IssuePrice { get; set; }
        public int? GcdIssueId { get; set; }

        public Title Title { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<IssueTag> Tags { get; set; }

    }

}
