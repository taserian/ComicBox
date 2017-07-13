using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicBox20170711.Migrations
{
    public partial class InitialDeployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GcdSeriesId = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    SeriesTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GcdIssueId = table.Column<int>(nullable: true),
                    IssueNumber = table.Column<int>(nullable: false),
                    IssuePrice = table.Column<decimal>(nullable: true),
                    IssueReleaseDate = table.Column<DateTime>(nullable: true),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issue_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookGrade = table.Column<int>(nullable: false),
                    CbcsGrade = table.Column<decimal>(nullable: true),
                    CgcGrade = table.Column<decimal>(nullable: true),
                    IssueId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                    table.ForeignKey(
                        name: "FK_Book_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bookid = table.Column<int>(nullable: true),
                    Bookid1 = table.Column<int>(nullable: true),
                    IssueId = table.Column<int>(nullable: true),
                    TagText = table.Column<string>(nullable: true),
                    TitleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TagId", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_Book_Bookid",
                        column: x => x.Bookid,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_Book_Bookid1",
                        column: x => x.Bookid1,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_IssueId",
                table: "Book",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_TitleId",
                table: "Issue",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Bookid",
                table: "Tag",
                column: "Bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Bookid1",
                table: "Tag",
                column: "Bookid1");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_IssueId",
                table: "Tag",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TitleId",
                table: "Tag",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
