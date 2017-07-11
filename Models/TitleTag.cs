using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBox.Models
{
    public class TitleTag
    {
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public int TagId { get; set; }
        public ItemTag Tag { get; set; }
    }
}
