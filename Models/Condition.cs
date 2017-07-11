using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace ComicBox.Models
{
    public class Condition: Tag
    {
        public ICollection<BookCondition> ConditionBooks { get; set; }
    }
}

