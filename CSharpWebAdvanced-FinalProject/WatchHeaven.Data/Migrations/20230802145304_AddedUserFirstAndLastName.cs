using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class AddedUserFirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("28e244e2-18b9-4974-99f6-8524c96e0427"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("72987733-cdee-437c-b6eb-9189fb4c1d83"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("7fa95b52-dfdc-457d-b094-2d50c2086749"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("89b293e4-932f-4b4a-a37c-4dd0d9f5c986"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("93e22177-2480-4747-98b3-476d7e90c756"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "FirstNameTest");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "LastNameTest");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("41429866-f074-4db6-8a5d-503294d56768"), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("4bb8c768-e1d0-4db7-b2b6-81845de6d02e"), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("5fa54553-6237-40f8-9171-a2f75a1716dc"), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("98ba5eaa-43a9-47db-a5d7-043ea085eae6"), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("d559a56c-c849-43c9-895a-38805662f12d"), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("41429866-f074-4db6-8a5d-503294d56768"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("4bb8c768-e1d0-4db7-b2b6-81845de6d02e"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("5fa54553-6237-40f8-9171-a2f75a1716dc"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("98ba5eaa-43a9-47db-a5d7-043ea085eae6"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("d559a56c-c849-43c9-895a-38805662f12d"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "AddedOn", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "IsActive", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("28e244e2-18b9-4974-99f6-8524c96e0427"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("72987733-cdee-437c-b6eb-9189fb4c1d83"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("7fa95b52-dfdc-457d-b094-2d50c2086749"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("89b293e4-932f-4b4a-a37c-4dd0d9f5c986"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("93e22177-2480-4747-98b3-476d7e90c756"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });
        }
    }
}
