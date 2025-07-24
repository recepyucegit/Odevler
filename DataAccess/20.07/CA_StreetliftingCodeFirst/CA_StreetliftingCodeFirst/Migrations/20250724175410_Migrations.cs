using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CA_StreetliftingCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadLift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Squat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenchPress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverHeadPress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PullUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PushUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HollowBodyHold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegRaise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpperBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowerBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Push = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pull = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineAndExercise",
                columns: table => new
                {
                    RoutineId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineAndExercise", x => new { x.RoutineId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_RoutineAndExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutineAndExercise_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measuraments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeckMeasure = table.Column<int>(type: "int", nullable: false),
                    ChestMeasure = table.Column<int>(type: "int", nullable: false),
                    BellyMeasure = table.Column<int>(type: "int", nullable: false),
                    QuadricepsMeasure = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measuraments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measuraments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "BenchPress", "DeadLift", "Dip", "HollowBodyHold", "LegRaise", "OverHeadPress", "Plank", "PullUp", "PushUp", "Row", "Squat" },
                values: new object[,]
                {
                    { 1, "Bench Press güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır.", "Deadlift güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır.", null, null, null, "Overhead Press güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır.", null, "Pull Up güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılır.", null, null, "Squat güçlenme fazında 4-8 Tekrar @8 RPE olarak yapılı." },
                    { 2, null, null, "Dip güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır.", null, null, null, null, null, "Push Up güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır.", "Row güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır.", null },
                    { 3, null, null, null, "Hollow Body Hold güçlenme fazında 30-60 sn @9 RPE olarak yapılır.", "Leg Raise güçlenme fazında 8-12 Tekrar @9 RPE olarak yapılır.", null, "Plank güçlenme fazında 30-60 @9 RPE olarak yapılır.", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Routines",
                columns: new[] { "Id", "Core", "FullBody", "Legs", "LowerBody", "Pull", "Push", "UpperBody" },
                values: new object[] { 1, "Deadlift-Plank-LegRaise", "Deadlift-Squat-BenchPress-PullUp-HollowBodyHold", "Squat", "Squat-Plank", "Row- Pullup ", "OHP-BenchPress", "Dips-Row-Pushup  " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NickName", "Password" },
                values: new object[,]
                {
                    { 1, "Streetlifter1@Streetlifter", "StreetLifterManiac1", "1234" },
                    { 2, "Streetlifter2@Streetlifter", "StreetLifterManiac2", "1234" },
                    { 3, "Streetlifter3@Streetlifter", "StreetLifterManiac3", "1234" }
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "Id", "Age", "Gender", "Name", "SurName", "UserId" },
                values: new object[,]
                {
                    { 1, 28, "Male", "StreetLifter", "Maniac1", 1 },
                    { 2, 30, "Fmale", "StreetLifter", "Maniac2", 2 },
                    { 3, 25, "Male", "StreetLifter", "Maniac3", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measuraments_UserId",
                table: "Measuraments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineAndExercise_ExerciseId",
                table: "RoutineAndExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measuraments");

            migrationBuilder.DropTable(
                name: "RoutineAndExercise");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
