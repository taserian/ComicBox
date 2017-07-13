using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ComicBox.Data;
using ComicBox.Models;

namespace ComicBox20170711.Migrations
{
    [DbContext(typeof(ComicBoxContext))]
    partial class ComicBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("ComicBox.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookGrade");

                    b.Property<decimal?>("CbcsGrade");

                    b.Property<decimal?>("CgcGrade");

                    b.Property<int?>("IssueId")
                        .IsRequired();

                    b.Property<string>("Location");

                    b.HasKey("id");

                    b.HasIndex("IssueId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ComicBox.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GcdIssueId");

                    b.Property<int>("IssueNumber");

                    b.Property<decimal?>("IssuePrice");

                    b.Property<DateTime?>("IssueReleaseDate");

                    b.Property<int?>("TitleId")
                        .IsRequired();

                    b.HasKey("IssueId");

                    b.HasIndex("TitleId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("ComicBox.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Bookid");

                    b.Property<int?>("Bookid1");

                    b.Property<int?>("IssueId");

                    b.Property<string>("TagText");

                    b.Property<int?>("TitleId");

                    b.HasKey("TagId")
                        .HasName("TagId");

                    b.HasIndex("Bookid");

                    b.HasIndex("Bookid1");

                    b.HasIndex("IssueId");

                    b.HasIndex("TitleId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ComicBox.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GcdSeriesId");

                    b.Property<string>("Publisher");

                    b.Property<string>("SeriesTitle");

                    b.HasKey("TitleId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("ComicBox.Models.Book", b =>
                {
                    b.HasOne("ComicBox.Models.Issue", "Issue")
                        .WithMany("Books")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComicBox.Models.Issue", b =>
                {
                    b.HasOne("ComicBox.Models.Title", "Title")
                        .WithMany("Issues")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComicBox.Models.Tag", b =>
                {
                    b.HasOne("ComicBox.Models.Book")
                        .WithMany("BookCondition")
                        .HasForeignKey("Bookid");

                    b.HasOne("ComicBox.Models.Book")
                        .WithMany("Tags")
                        .HasForeignKey("Bookid1");

                    b.HasOne("ComicBox.Models.Issue")
                        .WithMany("Tags")
                        .HasForeignKey("IssueId");

                    b.HasOne("ComicBox.Models.Title")
                        .WithMany("Tags")
                        .HasForeignKey("TitleId");
                });
        }
    }
}
