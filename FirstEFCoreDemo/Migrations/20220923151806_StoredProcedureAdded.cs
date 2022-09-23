using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstEFCoreDemo.Migrations
{
    public partial class StoredProcedureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp =@"create procedure dbo.GetBook @id int
                    as 
                    begin 
                    select * from Books where Id=@id
                    end";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.Sql("drop procedure GetBook");
        }
    }
}
