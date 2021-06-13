using Microsoft.EntityFrameworkCore.Migrations;

namespace city.data.Migrations
{
    public partial class ınitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    surname = table.Column<string>(type: "TEXT", nullable: true),
                    eposta = table.Column<string>(type: "TEXT", nullable: true),
                    il = table.Column<string>(type: "TEXT", nullable: true),
                    ilce = table.Column<string>(type: "TEXT", nullable: true),
                    posta_kodu = table.Column<string>(type: "TEXT", nullable: true),
                    adres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
