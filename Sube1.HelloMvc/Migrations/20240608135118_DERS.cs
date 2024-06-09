using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube1.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class oktay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAd = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DersKodu = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.Dersid);
                });

            migrationBuilder.CreateTable(
                name: "tblOgrenciDersler",
                columns: table => new
                {
                    ogrid = table.Column<int>(type: "int", nullable: false),
                    dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciDersler", x => new { x.ogrid, x.dersid });
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblDersler_dersid",
                        column: x => x.Dersid,
                        principalTable: "tblDersler",
                        principalColumn: "dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblOgrenciler_ogrid",
                        column: x => x.ogrid,
                        principalTable: "tblOgrenciler",
                        principalColumn: "ogrid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrenciDersler_dersid",
                table: "tblOgrenciDersler",
                column: "dersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDersler");

            migrationBuilder.DropTable(
                name: "tblDersler");
        }
    }
}
