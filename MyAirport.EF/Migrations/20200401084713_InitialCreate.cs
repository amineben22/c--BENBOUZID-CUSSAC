using System;
using Microsoft.EntityFrameworkCore.Migrations;
using AB.AC.MyAirport.EF;
namespace AB.AC.MyAirport.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    ID_VOL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIE = table.Column<string>(nullable: false),
                    LIG = table.Column<string>(nullable: false),
                    DHC = table.Column<DateTime>(nullable: true),
                    PKG = table.Column<string>(nullable: true),
                    IMM = table.Column<string>(nullable: true),
                    PAX = table.Column<int>(nullable: true),
                    DES = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.ID_VOL);
                });

            migrationBuilder.CreateTable(
                name: "Bagages",
                columns: table => new
                {
                    ID_BAGAGE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VOL = table.Column<int>(nullable: true),
                    CODE_IATA = table.Column<string>(nullable: true),
                    DATE_CREATION = table.Column<DateTime>(nullable: false),
                    CLASSE = table.Column<string>(nullable: true),
                    PRIORITAIRE = table.Column<byte>(nullable: true),
                    STA = table.Column<string>(nullable: true),
                    SSUR = table.Column<string>(nullable: true),
                    DESTINATION = table.Column<string>(nullable: true),
                    ESCALE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagages", x => x.ID_BAGAGE);
                    table.ForeignKey(
                        name: "FK_Bagages_Vols_ID_VOL",
                        column: x => x.ID_VOL,
                        principalTable: "Vols",
                        principalColumn: "ID_VOL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bagages_ID_VOL",
                table: "Bagages",
                column: "ID_VOL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bagages");

            migrationBuilder.DropTable(
                name: "Vols");
        }
    }
}
