using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_PetApp.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelter");
        }
    }
}
