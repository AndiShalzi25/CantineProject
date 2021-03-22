using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppAndi.Migrations
{
    public partial class CantineCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sectorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectorCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wineBarrelCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    SectorCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wineBarrelCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wineBarrelCategories_sectorCategories_SectorCategoryId",
                        column: x => x.SectorCategoryId,
                        principalTable: "sectorCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_wineBarrelCategories_SectorCategoryId",
                table: "wineBarrelCategories",
                column: "SectorCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wineBarrelCategories");

            migrationBuilder.DropTable(
                name: "sectorCategories");
        }
    }
}
