using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using webappEF.Models;

#nullable disable

namespace webappEF.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);

            var fakerArticle = new Faker<Article>()
                .RuleFor(a => a.Title, f => f.Lorem.Sentence())
                .RuleFor(a => a.Content, f => f.Lorem.Paragraphs(3))
                .RuleFor(a => a.CreatedAt, f => f.Date.Past());

            for (int i = 0; i < 150; i++)
            {
                var article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table: "Articles",
                    columns: new[] { "Title", "Content", "CreatedAt" },
                    values: new object[] { article.Title, article.Content, article.CreatedAt }
                );
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
