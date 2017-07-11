using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBox.Models
{
    public class BookCondition
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
    }
}
