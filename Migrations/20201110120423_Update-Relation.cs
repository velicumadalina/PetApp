using Microsoft.EntityFrameworkCore.Migrations;

namespace PetApp.Migrations
{
    public partial class UpdateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "UserShelterRelations");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserShelterRelations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserShelterRelations");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "UserShelterRelations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
