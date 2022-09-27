using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationDemo.Migrations
{
    public partial class DepartmentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employeess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeess_DepartmentId",
                table: "Employeess",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeess_Department_DepartmentId",
                table: "Employeess",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeess_Department_DepartmentId",
                table: "Employeess");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employeess_DepartmentId",
                table: "Employeess");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employeess");
        }
    }
}
