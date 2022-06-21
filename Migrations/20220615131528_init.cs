using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Api_Joke.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jokes_Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluation = table.Column<double>(type: "float", nullable: false),
                    EvaluationCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    WindSpeed = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Season = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jokes_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jokeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jokeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "jokes_General",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangePassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Evaluation = table.Column<double>(type: "float", nullable: false),
                    EvaluationCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JokeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jokes_General", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jokes_General_jokeTypes_JokeTypeId",
                        column: x => x.JokeTypeId,
                        principalTable: "jokeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jokes_General_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jokes_General_JokeTypeId",
                table: "jokes_General",
                column: "JokeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_jokes_General_UserName",
                table: "jokes_General",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jokes_General");

            migrationBuilder.DropTable(
                name: "jokes_Weather");

            migrationBuilder.DropTable(
                name: "jokeTypes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
