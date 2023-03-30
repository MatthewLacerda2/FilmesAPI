using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class cinemaefilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_cinemaID",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_filmeID",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "cinemaID",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                columns: new[] { "filmeID", "cinemaID" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "cinemaID",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_filmeID",
                table: "Sessoes",
                column: "filmeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_cinemaID",
                table: "Sessoes",
                column: "cinemaID",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }
    }
}
