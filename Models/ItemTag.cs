using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBox.Models
{
    public class ItemTag : Tag
    {
        public ICollection<TitleTag> TaggedTitles { get; set; }
        public ICollection<IssueTag> TaggedIssues { get; set; }
        public ICollection<BookTag> TaggedBooks { get; set; }

        public ItemTagShort ToShortData()
        {
            return new ItemTagShort(this);
        }
    }

    public class ItemTagShort
    {
        public int TagId { get; set; }
        public String Label { get; set; }

        public ItemTagShort(ItemTag tag)
        {
            this.TagId = tag.TagId;
            this.Label = tag.Label;
        }

    }

}
