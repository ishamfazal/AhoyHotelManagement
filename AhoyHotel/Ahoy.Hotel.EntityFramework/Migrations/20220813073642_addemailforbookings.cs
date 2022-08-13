using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahoy.Hotel.EntityFramework.Migrations
{
    public partial class addemailforbookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Booking",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Booking");
        }
    }
}
