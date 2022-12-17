using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEticketApplication.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteToFroms",
                columns: table => new
                {
                    RouteToId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteToName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteToFroms", x => x.RouteToId);
                });

            migrationBuilder.CreateTable(
                name: "RouteFroms",
                columns: table => new
                {
                    RouteFromId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteFromName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteFroms", x => x.RouteFromId);
                    table.ForeignKey(
                        name: "FK_RouteFroms_RouteToFroms_RouteToId",
                        column: x => x.RouteToId,
                        principalTable: "RouteToFroms",
                        principalColumn: "RouteToId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteFroms_RouteToId",
                table: "RouteFroms",
                column: "RouteToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteFroms");

            migrationBuilder.DropTable(
                name: "RouteToFroms");
        }
    }
}
