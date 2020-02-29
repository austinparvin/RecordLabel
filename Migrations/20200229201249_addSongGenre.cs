using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RecordLabel.Migrations
{
    public partial class addSongGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {








            migrationBuilder.CreateTable(
                name: "SongGenre",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    SongGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenre", x => new { x.SongId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_SongGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongGenre_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_SongGenre_GenreId",
                table: "SongGenre",
                column: "GenreId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongGenre");


        }
    }
}
