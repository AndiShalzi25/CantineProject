using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalCantineAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectorDatabase",
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
                    table.PrimaryKey("PK_SectorDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineBarrelDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineBarrelDatabase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineBarrelDatabase_SectorDatabase_SectorId",
                        column: x => x.SectorId,
                        principalTable: "SectorDatabase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineBarrelDatabase_SectorId",
                table: "WineBarrelDatabase",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineBarrelDatabase");

            migrationBuilder.DropTable(
                name: "SectorDatabase");
        }
    }
}
