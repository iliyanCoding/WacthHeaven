using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class FixAddedOnValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("11dcde85-d1c6-4e4a-b39b-16bddec2c377"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("15e455c3-fb92-43a9-ba5f-78f43a5c5561"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("27a9bc37-99ce-4413-96d8-63fa4e9675ea"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("5a75f25b-0fe6-4818-a04a-88d62277b1ef"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("7678d7e2-7eed-48fb-84a2-d37ef2b43c16"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Watches",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 17, 0, 16, 764, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("814605ec-05bf-4e03-a44a-fa21e7f9e781"), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("b460052e-3d78-45a1-84ea-601e5a1a8c62"), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("c00e2dff-0cfe-47b7-8299-331210c3ea92"), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("d4209125-7196-4205-8669-a257671f71dc"), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("efe9965c-1a79-4f5a-85f0-8db285497143"), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("814605ec-05bf-4e03-a44a-fa21e7f9e781"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("b460052e-3d78-45a1-84ea-601e5a1a8c62"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("c00e2dff-0cfe-47b7-8299-331210c3ea92"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("d4209125-7196-4205-8669-a257671f71dc"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("efe9965c-1a79-4f5a-85f0-8db285497143"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Watches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 17, 0, 16, 764, DateTimeKind.Utc).AddTicks(2463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "AddedOn", "ApplicationUserId", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("11dcde85-d1c6-4e4a-b39b-16bddec2c377"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("15e455c3-fb92-43a9-ba5f-78f43a5c5561"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("27a9bc37-99ce-4413-96d8-63fa4e9675ea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("5a75f25b-0fe6-4818-a04a-88d62277b1ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("7678d7e2-7eed-48fb-84a2-d37ef2b43c16"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });
        }
    }
}
