using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    public partial class soutenancesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Soutenance",
                columns: table => new
                {
                    SoutenanceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StageID = table.Column<int>(type: "INTEGER", nullable: false),
                    InstructorID = table.Column<int>(type: "INTEGER", nullable: false),
                    TitreDeSoutenance = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soutenance", x => x.SoutenanceID);
                    table.ForeignKey(
                        name: "FK_Soutenance_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Soutenance_Stage_StageID",
                        column: x => x.StageID,
                        principalTable: "Stage",
                        principalColumn: "StageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_InstructorID",
                table: "Soutenance",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_StageID",
                table: "Soutenance",
                column: "StageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soutenance");
        }
    }
}
