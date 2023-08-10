using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class AddedCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("1f97198f-06cb-4197-9f79-7f75cb9e8bb0"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("2d3b5895-3763-461c-8ab9-ba37e727b448"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("34dc45a8-df8a-4ab0-aeff-2c75d893516f"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("441a2117-6280-44c1-b44d-e9ceda46992a"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("96bc91e9-e97f-421d-92bd-38fd0e434944"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("dab01b4a-e4f9-4fb9-a735-c45d8f9dd8cf"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f0b3550a-71af-4c17-980f-5c2db13a6944"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f2bfb2e7-d04c-4d6b-93d6-dc627748927e"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f604345c-3586-400d-b918-4eb7bfd5702e"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f877500f-3f68-42a1-a77d-e276d2e0300b"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Watches_WatchId",
                        column: x => x.WatchId,
                        principalTable: "Watches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("0b5fb749-2f0e-41c8-b3f4-ccd831edf1fe"), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("18ed964b-1286-4611-831a-1b0e81bfacf9"), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("282092ed-41f5-49b4-8911-a2cb4f0f6998"), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("66c67e6f-7049-4789-9949-3797328a3835"), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("9251005b-7cc5-46ba-8d8c-763f4f56d185"), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("adfad0d6-afc6-4463-8f51-f711eada13c1"), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("c1a8e2f0-088a-46b5-b266-94cb41d7a6e3"), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("c8b96db7-3bfa-486b-900a-9d97404fc865"), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("dbcbe75a-d4c3-4beb-b59a-2d68504520ca"), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("e155b7ff-e2e5-4ad9-96fa-93945bd49c81"), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WatchId",
                table: "Comments",
                column: "WatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("0b5fb749-2f0e-41c8-b3f4-ccd831edf1fe"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("18ed964b-1286-4611-831a-1b0e81bfacf9"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("282092ed-41f5-49b4-8911-a2cb4f0f6998"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("66c67e6f-7049-4789-9949-3797328a3835"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("9251005b-7cc5-46ba-8d8c-763f4f56d185"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("adfad0d6-afc6-4463-8f51-f711eada13c1"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("c1a8e2f0-088a-46b5-b266-94cb41d7a6e3"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("c8b96db7-3bfa-486b-900a-9d97404fc865"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("dbcbe75a-d4c3-4beb-b59a-2d68504520ca"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("e155b7ff-e2e5-4ad9-96fa-93945bd49c81"));

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "AddedOn", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "IsActive", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("1f97198f-06cb-4197-9f79-7f75cb9e8bb0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("2d3b5895-3763-461c-8ab9-ba37e727b448"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("34dc45a8-df8a-4ab0-aeff-2c75d893516f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("441a2117-6280-44c1-b44d-e9ceda46992a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("96bc91e9-e97f-421d-92bd-38fd0e434944"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("dab01b4a-e4f9-4fb9-a735-c45d8f9dd8cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("f0b3550a-71af-4c17-980f-5c2db13a6944"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("f2bfb2e7-d04c-4d6b-93d6-dc627748927e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("f604345c-3586-400d-b918-4eb7bfd5702e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("f877500f-3f68-42a1-a77d-e276d2e0300b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") }
                });
        }
    }
}
