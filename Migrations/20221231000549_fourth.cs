using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEticketApplication.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    TransportTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.TransportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransportInfo",
                columns: table => new
                {
                    TransportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNo = table.Column<int>(type: "int", nullable: false),
                    TransportTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportInfo", x => x.TransportId);
                    table.ForeignKey(
                        name: "FK_TransportInfo_TransportTypes_TransportTypeId",
                        column: x => x.TransportTypeId,
                        principalTable: "TransportTypes",
                        principalColumn: "TransportTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportInfo_TransportTypeId",
                table: "TransportInfo",
                column: "TransportTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportInfo");

            migrationBuilder.DropTable(
                name: "TransportTypes");
        }
    }
}
