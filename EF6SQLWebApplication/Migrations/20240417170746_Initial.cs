using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF6SQLWebApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RpgCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterClass = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpgCharacterInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RpgCharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgCharacterInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RpgCharacterInventory_RpgCharacters_RpgCharacterId",
                        column: x => x.RpgCharacterId,
                        principalTable: "RpgCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RpgCharacterInventory_RpgCharacterId",
                table: "RpgCharacterInventory",
                column: "RpgCharacterId");

            migrationBuilder.InsertData(
                table: "RpgCharacters",
                columns: new[] { "Name", "CharacterClass", "HitPoints" },
                values: new object[,]
                {
            { "Character1", 0 , 100 },
            { "Character2", 1 , 80 }
                });

            migrationBuilder.InsertData(
                table: "RpgCharacterInventory",
                columns: new[] { "RpgCharacterId", "ItemName", "Quantity" },
                values: new object[,]
                {
                    { 1 , "Sword", 1 },
                    { 2 , "Staff", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RpgCharacterInventory");

            migrationBuilder.DropTable(
                name: "RpgCharacters");
        }
    }
}
