using Microsoft.EntityFrameworkCore.Migrations;

namespace AV_Soft.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tab1",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KEY = table.Column<int>(nullable: false),
                    VALUE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tab2",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KEY = table.Column<int>(nullable: false),
                    COUNT = table.Column<int>(nullable: false),
                    COUNTMORETHENONE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab2", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tab1");

            migrationBuilder.DropTable(
                name: "Tab2");
        }
    }
}
