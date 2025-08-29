using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjeKampi.WebApi.Migrations
{
    public partial class mig_6_2_Guncelleme_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Massage",
                table: "Reservations",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Emali",
                table: "Reservations",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Reservations",
                newName: "Massage");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Reservations",
                newName: "Emali");
        }
    }
}
