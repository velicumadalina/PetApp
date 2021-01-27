using Microsoft.EntityFrameworkCore.Migrations;

namespace PetApp.Migrations
{
    public partial class addcoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetsAlongWith",
                table: "Animal");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Shelter",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Shelter",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Shelter");

            migrationBuilder.AddColumn<string>(
                name: "GetsAlongWith",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
