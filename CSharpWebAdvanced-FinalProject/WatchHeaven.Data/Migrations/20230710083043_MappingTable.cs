using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class MappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesWatches_AspNetUsers_ApplicationUserId",
                table: "FavouritesWatches");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesWatches_Watches_WatchId",
                table: "FavouritesWatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches");

            migrationBuilder.RenameTable(
                name: "FavouritesWatches",
                newName: "FavouriteWatches");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritesWatches_WatchId",
                table: "FavouriteWatches",
                newName: "IX_FavouriteWatches_WatchId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritesWatches_ApplicationUserId",
                table: "FavouriteWatches",
                newName: "IX_FavouriteWatches_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteWatches",
                table: "FavouriteWatches",
                columns: new[] { "UserId", "WatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteWatches_AspNetUsers_ApplicationUserId",
                table: "FavouriteWatches",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteWatches_Watches_WatchId",
                table: "FavouriteWatches",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteWatches_AspNetUsers_ApplicationUserId",
                table: "FavouriteWatches");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteWatches_Watches_WatchId",
                table: "FavouriteWatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteWatches",
                table: "FavouriteWatches");

            migrationBuilder.RenameTable(
                name: "FavouriteWatches",
                newName: "FavouritesWatches");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteWatches_WatchId",
                table: "FavouritesWatches",
                newName: "IX_FavouritesWatches_WatchId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteWatches_ApplicationUserId",
                table: "FavouritesWatches",
                newName: "IX_FavouritesWatches_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouritesWatches",
                table: "FavouritesWatches",
                columns: new[] { "UserId", "WatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesWatches_AspNetUsers_ApplicationUserId",
                table: "FavouritesWatches",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesWatches_Watches_WatchId",
                table: "FavouritesWatches",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
