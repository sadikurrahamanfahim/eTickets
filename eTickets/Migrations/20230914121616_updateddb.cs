using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class updateddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Movies_MovieID",
                table: "Actor_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_ProducerID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Movies",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_ProducerID",
                table: "Movies",
                newName: "IX_Movies_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaID",
                table: "Movies",
                newName: "IX_Movies_CinemaId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Actor_Movies",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_Movies_MovieID",
                table: "Actor_Movies",
                newName: "IX_Actor_Movies_MovieId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Movies_MovieId",
                table: "Actor_Movies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_ProducerId",
                table: "Movies",
                column: "ProducerID",
                principalTable: "Producers",
                principalColumn: "ProducerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Movies_MovieId",
                table: "Actor_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_ProducerId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Movies",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                newName: "IX_Movies_ProducerID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                newName: "IX_Movies_CinemaID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Actor_Movies",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_Movies_MovieId",
                table: "Actor_Movies",
                newName: "IX_Actor_Movies_MovieID");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Movies_MovieID",
                table: "Actor_Movies",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaID",
                table: "Movies",
                column: "MovieId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_ProducerID",
                table: "Movies",
                column: "ProducerID",
                principalTable: "Producers",
                principalColumn: "ProducerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
