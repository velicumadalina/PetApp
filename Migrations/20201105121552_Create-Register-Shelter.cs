using Microsoft.EntityFrameworkCore.Migrations;

namespace PetApp.Migrations
{
    public partial class CreateRegisterShelter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShelter",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShelter",
                table: "AspNetUsers");
        }
    }
}
