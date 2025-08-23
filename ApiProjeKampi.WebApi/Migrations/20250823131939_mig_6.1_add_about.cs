using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjeKampi.WebApi.Migrations
{
    public partial class mig_61_add_about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titile",
                table: "Abouts",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Abouts",
                newName: "Titile");
        }
    }
}
