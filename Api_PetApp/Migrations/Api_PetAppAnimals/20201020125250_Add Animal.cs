using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_PetApp.Migrations.Api_PetAppAnimals
{
    public partial class AddAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ShelterId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Characteristics = table.Column<string>(nullable: true),
                    EnergyLevel = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Hair = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FriendlyWithDogs = table.Column<bool>(nullable: false),
                    FriendlyWithCats = table.Column<bool>(nullable: false),
                    FriendlyWithKids = table.Column<bool>(nullable: false),
                    SpecialNeeds = table.Column<bool>(nullable: false),
                    IsAdopted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Shelter");
        }
    }
}
