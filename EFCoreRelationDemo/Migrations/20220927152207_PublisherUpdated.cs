using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationDemo.Migrations
{
    public partial class PublisherUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PubId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BKId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    PubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BKId);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PubId",
                        column: x => x.PubId,
                        principalTable: "Publishers",
                        principalColumn: "PubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PubId",
                table: "Books",
                column: "PubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
