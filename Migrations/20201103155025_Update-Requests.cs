using Microsoft.EntityFrameworkCore.Migrations;

namespace PetApp.Migrations
{
    public partial class UpdateRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdoptionStatus",
                table: "adoptionRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimalImage",
                table: "adoptionRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimalName",
                table: "adoptionRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdoptionStatus",
                table: "adoptionRequests");

            migrationBuilder.DropColumn(
                name: "AnimalImage",
                table: "adoptionRequests");

            migrationBuilder.DropColumn(
                name: "AnimalName",
                table: "adoptionRequests");
        }
    }
}
