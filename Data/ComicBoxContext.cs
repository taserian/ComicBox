using ComicBox.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Context for ComicBox application
/// </summary>
///

namespace ComicBox.Data
{
    public class ComicBoxContext : DbContext
    {
        public DbSet<Title> titles { get; set; }
        public DbSet<Issue> issues { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Tag> tags { get; set; }
        //public DbSet<TitleTag> titleTags { get; set; }
        //public DbSet<IssueTag> issueTags { get; set; }
        //public DbSet<BookTag> bookTags { get; set; }
        //public DbSet<Condition> conditions { get; set; }
        //public DbSet<BookCondition> conditionTags { get; set; }

        public ComicBoxContext(DbContextOptions<ComicBoxContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasMany(c => c.Issues).WithOne(e => e.Title).IsRequired();

                entity.ToTable("Title");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasMany(c => c.Books).WithOne(e => e.Issue).IsRequired();

                entity.ToTable("Issue");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(i => i.TagId).HasName("TagId");

                entity.ToTable("Tag");
            });

            //modelBuilder.Entity<TitleTag>(entity =>
            //{
            //    entity.HasKey(e => new { e.TitleId, e.TagId })
            //    .HasName("PK_TitleTag");

            //    entity.HasIndex(e => e.TitleId)
            //    .HasName("IX_TitleTag_TitleId");

            //    entity.HasIndex(e => e.TagId)
            //    .HasName("IX_TitleTag_TagId");

            //    entity.HasOne(i => i.Title)
            //    .WithMany(a => a.Tags)
            //    .HasForeignKey(d => d.TitleId);

            //    entity.HasOne(i => i.Tag)
            //    .WithMany(a => a.TaggedTitles)
            //    .HasForeignKey(d => d.TagId);

            //    entity.ToTable("TitleTag");
            //});

            //modelBuilder.Entity<IssueTag>(entity =>
            //{
            //    entity.HasKey(e => new { e.IssueId, e.TagId })
            //    .HasName("PK_IssueTag");

            //    entity.HasIndex(e => e.IssueId)
            //    .HasName("IX_IssueTag_IssueId");

            //    entity.HasIndex(e => e.TagId)
            //    .HasName("IX_IssueTag_TagId");

            //    entity.HasOne(i => i.Issue)
            //    .WithMany(a => a.Tags)
            //    .HasForeignKey(d => d.IssueId);

            //    entity.HasOne(i => i.Tag)
            //    .WithMany(a => a.TaggedIssues)
            //    .HasForeignKey(d => d.TagId);

            //    entity.ToTable("IssueTag");
            //});

            //modelBuilder.Entity<BookTag>(entity =>
            //{
            //    entity.HasKey(e => new { e.BookId, e.TagId })
            //    .HasName("PK_BookTag");

            //    entity.HasIndex(e => e.BookId)
            //    .HasName("IX_BookTag_BookId");

            //    entity.HasIndex(e => e.TagId)
            //    .HasName("IX_BookTag_TagId");

            //    entity.HasOne(i => i.Book)
            //    .WithMany(a => a.Tags)
            //    .HasForeignKey(d => d.BookId);

            //    entity.HasOne(i => i.Tag)
            //    .WithMany(a => a.TaggedBooks)
            //    .HasForeignKey(d => d.TagId);

            //    entity.ToTable("BookTag");
            //});

            // modelBuilder.Entity<Condition>(entity =>
            //{
            //    entity.HasKey(c => c.TagId).HasName("ConditionId");
            //    entity.ToTable("Condition");
            //});

            //modelBuilder.Entity<BookCondition>(entity =>
            //{
            //    entity.HasKey(e => new { e.BookId, e.ConditionId })
            //    .HasName("PK_Condition");

            //    entity.HasIndex(e => e.BookId)
            //    .HasName("IX_BookCondition_BookId");

            //    entity.HasIndex(e => e.ConditionId)
            //    .HasName("IX_BookCondition_ConditionId");

            //    entity.HasOne(i => i.Book)
            //    .WithMany(a => a.BookCondition)
            //    .HasForeignKey(d => d.BookId);

            //    entity.HasOne(i => i.Condition)
            //    .WithMany(a => a.ConditionBooks)
            //    .HasForeignKey(d => d.ConditionId);

            //    entity.ToTable("BookCondition");
            //});
        }
    }
}