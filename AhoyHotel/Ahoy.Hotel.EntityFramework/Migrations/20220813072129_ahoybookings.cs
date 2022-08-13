using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahoy.Hotel.EntityFramework.Migrations
{
    public partial class ahoybookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BookingReference = table.Column<string>(nullable: true),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    NoOfDays = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    NoOfPeople = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HotelId",
                table: "Booking",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
