using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBox.Models
{
    public class IssueTag
    {
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int TagId { get; set; }
        public ItemTag Tag { get; set; }
    }
}
