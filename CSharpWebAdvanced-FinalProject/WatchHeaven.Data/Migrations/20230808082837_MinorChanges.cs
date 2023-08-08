using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_ShoppingCarts_ShoppingCartUserId",
                table: "Watches");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Watches_ShoppingCartUserId",
                table: "Watches");

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("08224a6b-3a9c-4bdf-836b-7ea927d98ee3"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("088fbf23-ee79-4526-b807-62a562129836"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("41731b4e-f162-4335-aab3-fe5374552434"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("5202ae20-82db-4a39-a723-650302a0d88f"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("631067ad-9669-4f3b-936c-47c00fa03228"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("79c74b00-63cd-4375-a331-040ca23004c9"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("abf4d078-d1b3-4fd8-a984-f180aced3e63"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("b4e52e2e-35ed-4e6b-af5d-4b4017457013"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("bfb44dfb-8d8c-452c-993b-e46e931bce1f"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("e3d97d74-65a0-4ffa-94e5-08e1336c5bed"));

            migrationBuilder.DropColumn(
                name: "ShoppingCartUserId",
                table: "Watches");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("372cfd1a-81ca-4857-9cd9-f0d4d217fbec"), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("906a9b73-2e73-44c8-a884-2f45004bb4d6"), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("94ed7900-bb04-471b-b16e-c9442a84277b"), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("9e4e2e78-0a7a-4f24-a6ae-d531dab4e712"), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("a60bb79f-0249-487d-8b53-285553bef4ba"), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("c31cff93-6287-4b26-a189-31327471eb49"), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("df25b2ac-1b26-4c4c-bceb-eeaaebe3e6da"), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("e9bfc4de-a327-44cb-a9d0-8d266167968d"), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("f0016b9b-3905-4f76-8777-19e3c402b10f"), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("f3dffc20-2a7d-42c8-a34e-9c348743317c"), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("372cfd1a-81ca-4857-9cd9-f0d4d217fbec"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("906a9b73-2e73-44c8-a884-2f45004bb4d6"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("94ed7900-bb04-471b-b16e-c9442a84277b"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("9e4e2e78-0a7a-4f24-a6ae-d531dab4e712"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("a60bb79f-0249-487d-8b53-285553bef4ba"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("c31cff93-6287-4b26-a189-31327471eb49"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("df25b2ac-1b26-4c4c-bceb-eeaaebe3e6da"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("e9bfc4de-a327-44cb-a9d0-8d266167968d"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f0016b9b-3905-4f76-8777-19e3c402b10f"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("f3dffc20-2a7d-42c8-a34e-9c348743317c"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartUserId",
                table: "Watches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartUserId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ShoppingCartUserId",
                        column: x => x.ShoppingCartUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "AddedOn", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "IsActive", "Model", "Price", "SellerId", "ShoppingCartUserId" },
                values: new object[,]
                {
                    { new Guid("08224a6b-3a9c-4bdf-836b-7ea927d98ee3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("088fbf23-ee79-4526-b807-62a562129836"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("41731b4e-f162-4335-aab3-fe5374552434"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5202ae20-82db-4a39-a723-650302a0d88f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("631067ad-9669-4f3b-936c-47c00fa03228"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("79c74b00-63cd-4375-a331-040ca23004c9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("abf4d078-d1b3-4fd8-a984-f180aced3e63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b4e52e2e-35ed-4e6b-af5d-4b4017457013"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bfb44dfb-8d8c-452c-993b-e46e931bce1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e3d97d74-65a0-4ffa-94e5-08e1336c5bed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watches_ShoppingCartUserId",
                table: "Watches",
                column: "ShoppingCartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_ShoppingCarts_ShoppingCartUserId",
                table: "Watches",
                column: "ShoppingCartUserId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
