using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class ledentabeltoegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leden",
                columns: table => new
                {
                    LidId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Tussenvoegsel = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Aanhef = table.Column<string>(nullable: true),
                    Geslacht = table.Column<string>(nullable: true),
                    PostAdres = table.Column<string>(nullable: true),
                    Plaats = table.Column<string>(nullable: true),
                    Tel = table.Column<int>(nullable: false),
                    Mobiel = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    SoortLid = table.Column<string>(nullable: true),
                    Betaald = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leden", x => x.LidId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leden");
        }
    }
}
