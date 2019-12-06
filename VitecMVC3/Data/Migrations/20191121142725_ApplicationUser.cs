using Microsoft.EntityFrameworkCore.Migrations;

namespace VitecMVC3.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AddColumn<bool>(
            //    name: "HasProduct",
            //    table: "AspNetUsers",
            //    nullable: false,
            //    defaultValue: false);
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "HasProduct",
               table: "AspNetUsers");
        }
    }
}
