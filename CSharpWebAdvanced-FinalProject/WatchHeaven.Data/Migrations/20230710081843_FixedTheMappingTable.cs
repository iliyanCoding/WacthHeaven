using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class FixedTheMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches",
                columns: new[] { "UserId", "WatchId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches",
                column: "UserId");
        }
    }
}
