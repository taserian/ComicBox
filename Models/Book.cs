using System;
using System.Collections.Generic;

/// <summary>
/// Physical comic book, which can be bought/sold.
/// </summary>
namespace ComicBox.Models
{
    public class Book
    {
        public int id { get; set; }
        public String Location { get; set; }
        public Grade BookGrade { get; set; }
        public decimal? CbcsGrade { get; set; }
        public decimal? CgcGrade { get; set; }

        public Issue Issue { get; set; }
        public ICollection<BookCondition> BookCondition { get; set; }
        public ICollection<BookTag> Tags { get; set; }
    }

    public enum Grade
    {
        UNKNOWN,
        Poor,
        Fair,
        Good,
        VeryGood,
        Fine,
        VeryFine,
        NearMint,
        Mint
    }
}