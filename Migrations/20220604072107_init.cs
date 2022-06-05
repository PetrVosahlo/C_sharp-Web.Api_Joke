using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Api_Joke.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "jokes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangePassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Evaluation = table.Column<double>(type: "float", nullable: false),
                    EvaluationCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JokeTypeId = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    SunRain = table.Column<bool>(type: "bit", nullable: false),
                    Wind = table.Column<double>(type: "float", nullable: false),
                    Snow = table.Column<bool>(type: "bit", nullable: false),
                    Season = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jokes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jokes_jokeTypes_JokeTypeId",
                        column: x => x.JokeTypeId,
                        principalTable: "jokeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jokes_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jokes_JokeTypeId",
                table: "jokes",
                column: "JokeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_jokes_UserName",
                table: "jokes",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jokes");

            migrationBuilder.DropTable(
                name: "jokeTypes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
