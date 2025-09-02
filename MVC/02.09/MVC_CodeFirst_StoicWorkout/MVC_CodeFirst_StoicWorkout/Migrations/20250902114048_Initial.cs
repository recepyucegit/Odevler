using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CodeFirst_StoicWorkout.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PullUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Squat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunge = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PullUpSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushUpSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegsSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleUpSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DipSimple = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Routines");
        }
    }
}
