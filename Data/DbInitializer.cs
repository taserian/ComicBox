using System;
using ComicBox.Models;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace ComicBox.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ComicBoxContext context)
        {
            context.Database.EnsureCreated();

            if (context.books.Any())
            {
                return;
            }

            //Title asm = context.titles.Single(t => t.seriesTitle == "Amazing Spider-Man");
            //int asmId = asm.titleId;

            //var issues = new Issue[]
            //{
            //    new Issue{titleId=asmId,issueNumber=13,issueReleaseDate=DateTime.Parse("2016-06-01"),issuePrice=3.99M,gcdIssueId=1576777}
            //};
            //foreach (Issue i in issues)
            //{
            //    context.issues.Add(i);
            //}
            //context.SaveChanges();

            //Issue i13 = context.issues.Single(i => i.titleId == asmId && i.issueNumber == 13);
            //int i13Id = i13.issueId;

            var books = new Book[]
            {
                new Book{Issue= new Issue{
                        Title= new Title{
                            Publisher="Marvel",
                            SeriesTitle ="Amazing Spider-Man",
                            GcdSeriesId =92892,
                            Tags=new List<TitleTag>{
                                new TitleTag{
                                    Tag = new ItemTag{Label="Subscribed"}
                                }
                            }
                        },
                        IssueNumber=13,
                        IssuePrice =3.99M,
                        GcdIssueId =1576777,
                        Tags=new List<IssueTag>{
                            new IssueTag{
                                Tag = new ItemTag{Label="Spider-Man/Iron Man crossover" }
                            }
                        },
                },
                Location="Box 23",
                BookGrade=Grade.Fine,
                BookCondition=new List<BookCondition>{
                    new BookCondition{
                        Condition = new Condition{
                            Label ="Yellowed pages"
                        }
                    }
                },
                Tags=new List<BookTag>{
                    new BookTag{Tag = new ItemTag { Label = "owned" } },
                    new BookTag{Tag = new ItemTag { Label = "Comic-Con 2017 (get signature)" } } }
                }
            };
            foreach (Book b in books)
            {
                context.books.Add(b);
            }

            var titles = new Title[]
            {
                new Title{Publisher="Marvel",SeriesTitle="Spectacular Spider-Man",GcdSeriesId=2359},
                new Title{Publisher="Marvel",SeriesTitle="Iron Man",GcdSeriesId=1867},
                new Title{Publisher="Marvel",SeriesTitle="Invincible Iron Man",GcdSeriesId=30723},
                new Title{Publisher="DC",SeriesTitle="Superman",GcdSeriesId=116},
                new Title{Publisher="DC",SeriesTitle="Superman: Man of Steel",GcdSeriesId=4215},
                new Title{Publisher="DC",SeriesTitle="Batman",GcdSeriesId=141},
                new Title{Publisher="DC",SeriesTitle="Legends of the Dark Night",GcdSeriesId=3809},
                new Title{Publisher="DC",SeriesTitle="Wonder Woman",GcdSeriesId=277},
                new Title{Publisher="DC",SeriesTitle="Legend of Wonder Woman",GcdSeriesId=3155}
            };
            foreach (Title t in titles)
            {
                context.titles.Add(t);
            }

            context.SaveChanges();

        }
    }
}

