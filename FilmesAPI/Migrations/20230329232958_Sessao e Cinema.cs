using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class SessaoeCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cinemaID",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_cinemaID",
                table: "Sessoes",
                column: "cinemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_cinemaID",
                table: "Sessoes",
                column: "cinemaID",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_cinemaID",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_cinemaID",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "cinemaID",
                table: "Sessoes");
        }
    }
}
