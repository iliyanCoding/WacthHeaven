using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchHeaven.Data.Migrations
{
    public partial class AddedNavigationPropertiesToWachAndApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("15257d4d-b208-4612-9719-77b72625ae47"), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("19ff2a18-3c87-4c06-8f85-a46e6e7fa6c4"), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("34f39747-b9d9-4d74-b307-8ed9eea36cf1"), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("3e9b8b52-411e-46b4-85f8-6b20e755527c"), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("53b7e871-8c00-4f84-b4ec-1fa0dc739c35"), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("71428fba-01b1-4d0a-b3f2-cd57ac6ca211"), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("a885e2a9-b5fa-4878-b3be-2d42fd73a4f3"), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("a89436fa-85fb-4165-abe3-c3800753ced0"), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("dc3b389e-1fed-43f6-b65c-714102d6def4"), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("ea2ed9f3-6d41-4070-9584-0e9e131ab96c"), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("15257d4d-b208-4612-9719-77b72625ae47"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("19ff2a18-3c87-4c06-8f85-a46e6e7fa6c4"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("34f39747-b9d9-4d74-b307-8ed9eea36cf1"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("3e9b8b52-411e-46b4-85f8-6b20e755527c"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("53b7e871-8c00-4f84-b4ec-1fa0dc739c35"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("71428fba-01b1-4d0a-b3f2-cd57ac6ca211"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("a885e2a9-b5fa-4878-b3be-2d42fd73a4f3"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("a89436fa-85fb-4165-abe3-c3800753ced0"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("dc3b389e-1fed-43f6-b65c-714102d6def4"));

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: new Guid("ea2ed9f3-6d41-4070-9584-0e9e131ab96c"));

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "AddedOn", "Brand", "CategoryId", "ConditionId", "Description", "ImageUrl", "IsActive", "Model", "Price", "SellerId" },
                values: new object[,]
                {
                    { new Guid("0b5fb749-2f0e-41c8-b3f4-ccd831edf1fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("18ed964b-1286-4611-831a-1b0e81bfacf9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seiko", 3, 1, "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.", "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png", false, "Prospex", 3200.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("282092ed-41f5-49b4-8911-a2cb4f0f6998"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("66c67e6f-7049-4789-9949-3797328a3835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("9251005b-7cc5-46ba-8d8c-763f4f56d185"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("adfad0d6-afc6-4463-8f51-f711eada13c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universal Geneve", 2, 3, "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.", "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg", false, "Aero-Compax", 17500.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("c1a8e2f0-088a-46b5-b266-94cb41d7a6e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWC Portuguese Chronograph", 1, 2, "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you", "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg", false, "iw371415", 9995.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("c8b96db7-3bfa-486b-900a-9d97404fc865"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breitling", 4, 2, "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal", "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg", false, "Navitimer World", 5995.00m, new Guid("bc37c605-d12f-4a25-a0e9-57d2b75d5b97") },
                    { new Guid("dbcbe75a-d4c3-4beb-b59a-2d68504520ca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") },
                    { new Guid("e155b7ff-e2e5-4ad9-96fa-93945bd49c81"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zenith", 5, 4, "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!", "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg", false, "Pilot", 775.00m, new Guid("498a11db-2703-49db-bd42-cc4f3542ea9a") }
                });
        }
    }
}
