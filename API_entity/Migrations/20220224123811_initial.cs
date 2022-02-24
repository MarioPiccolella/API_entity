using Microsoft.EntityFrameworkCore.Migrations;

namespace API_entity.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    pkid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.pkid);
                });

            migrationBuilder.CreateTable(
                name: "washers",
                columns: table => new
                {
                    pkid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_washers", x => x.pkid);
                });

            migrationBuilder.CreateTable(
                name: "washers_skills",
                columns: table => new
                {
                    pkid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    washer_id = table.Column<int>(type: "int", nullable: false),
                    skill_id = table.Column<int>(type: "int", nullable: false),
                    Skillpkid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_washers_skills", x => x.pkid);
                    table.ForeignKey(
                        name: "FK_washers_skills_skills_Skillpkid",
                        column: x => x.Skillpkid,
                        principalTable: "skills",
                        principalColumn: "pkid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_washers_skills_washers_washer_id",
                        column: x => x.washer_id,
                        principalTable: "washers",
                        principalColumn: "pkid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_washers_skills_Skillpkid",
                table: "washers_skills",
                column: "Skillpkid");

            migrationBuilder.CreateIndex(
                name: "IX_washers_skills_washer_id",
                table: "washers_skills",
                column: "washer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "washers_skills");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "washers");
        }
    }
}
