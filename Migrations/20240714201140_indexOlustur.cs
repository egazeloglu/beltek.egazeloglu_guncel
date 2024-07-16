using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beltek.egazeloglu.Migrations
{
    public partial class indexOlustur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_tblOgrenciler_SinifId",
                table: "tblOgrenciler",
                newName: "SinifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "SinifId",
                table: "tblOgrenciler",
                newName: "IX_tblOgrenciler_SinifId");
        }
    }
}
