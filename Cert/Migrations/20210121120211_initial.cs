using Microsoft.EntityFrameworkCore.Migrations;

namespace Cert.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uchastniki_SMEV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Polnoe_naimenovanie_Uchastnika = table.Column<string>(nullable: true),
                    Kratkoe_naimenovanie_Uchastnika = table.Column<string>(nullable: true),
                    OGRN = table.Column<string>(nullable: true),
                    Tip_Uchastnika = table.Column<int>(nullable: false),
                    Mnemonika_Uchastnika_v_SMEV3 = table.Column<string>(nullable: true),
                    Polnoe_naimenovanie_IS = table.Column<string>(nullable: true),
                    Kratkoe_naimenovanie_IS = table.Column<string>(nullable: true),
                    Mnemonika_IS_v_SMEV3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uchastniki_SMEV", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uchastniki_SMEV");
        }
    }
}
