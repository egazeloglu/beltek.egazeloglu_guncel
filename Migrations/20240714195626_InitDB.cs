using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beltek.egazeloglu.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSiniflar",
                columns: table => new
                {
                    SinifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kontenjan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSiniflar", x => x.SinifId);
                });

            migrationBuilder.CreateTable(
                name: "tblOgrenciler",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciNumara = table.Column<int>(type: "int", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciler", x => x.OgrenciId);
                    table.ForeignKey(
                        name: "FK_tblOgrenciler_tblSiniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "tblSiniflar",
                        principalColumn: "SinifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrenciler_SinifId",
                table: "tblOgrenciler",
                column: "SinifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciler");

            migrationBuilder.DropTable(
                name: "tblSiniflar");
        }
    }
}
