using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFInheritanceDemo.Migrations
{
    public partial class BlogAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "RssBlogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    RssURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RssBlogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_RssBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId");
                });

            migrationBuilder.CreateTable(
                name: "SampleBlogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    BlogURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleBlogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_SampleBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RssBlogs");

            migrationBuilder.DropTable(
                name: "SampleBlogs");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
