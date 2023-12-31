﻿

using WatchHeaven.Data.Model;
using WatchHeaven.Web.Data;

namespace WatchHeaven.Services.Tests
{
    public static class DbSeeder
    {
        public static ApplicationUser SellerUser;
        public static Seller Seller;
        public static Watch Watch;
        public static ICollection<Category> Categories;
        public static ICollection<Condition> Conditions;

        public static void SeedDb(WatchHeavenDbContext dbContext)
        {
            SellerUser = new ApplicationUser()
            {
                Id = Guid.Parse("b2239fcd-944d-4fa6-90ca-e1abaaa694df"),
                UserName = "seller@seller.com",
                NormalizedUserName = "SELLER@SELLER.COM",
                Email = "seller@seller.com",
                NormalizedEmail = "SELLER@SELLER.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "eab2397c-21c3-4ebd-89a1-485c6b1d28d2",
                SecurityStamp = "d3f14a8e-6850-49f8-b0e0-7b0e44f6b3c8",
                TwoFactorEnabled = false,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest"
            };
            Seller = new Seller()
            {
                Id = Guid.Parse("c1ff0048-2c60-45bf-a111-123405281b43"),
                PhoneNumber = "+359444444444",
                Address = "Some random address 1",
                User = SellerUser,
            };

            Watch = new Watch()
            {
                Id = Guid.Parse("86080918-9815-408d-8261-8a0fbf6350a3"),
                Brand = "Test brand",
                Model = "Test model",
                Description = "A really cool watch for testing",
                Price = 550.00m,
                ImageUrl = "randomImgUrl",
                AddedOn = DateTime.UtcNow,
                IsActive = true,
                CategoryId = 1,
                ConditionId = 1,
                SellerId = Guid.Parse("c1ff0048-2c60-45bf-a111-123405281b43")
            };

            dbContext.Watches.Add(Watch);

            Watch = new Watch()
            {
                Id = Guid.Parse("b4249945-b9d9-4a26-82a0-b5bbc30d20f4"),
                Brand = "Test brand 2",
                Model = "Test model 2",
                Description = "A really cool watch for testing",
                Price = 2550.00m,
                ImageUrl = "randomImgUrl2",
                AddedOn = DateTime.UtcNow,
                IsActive = true,
                CategoryId = 2,
                ConditionId = 2,
                SellerId = Guid.Parse("c1ff0048-2c60-45bf-a111-123405281b43")
            };

            dbContext.Watches.Add(Watch);

            Categories = new List<Category>
            {
            new Category { Id = 1, Name = "Vintage" },
            new Category { Id = 2, Name = "Pilot's" },
            new Category { Id = 3, Name = "Diving" },
            };

            Conditions = new List<Condition>
            {
            new Condition { Id = 1, Name = "New" },
            new Condition { Id = 2, Name = "Very Good" },
            new Condition { Id = 3, Name = "Fair" },
            };

            dbContext.Users.Add(SellerUser);
            dbContext.Sellers.Add(Seller);
            dbContext.Categories.AddRange(Categories);
            dbContext.Conditions.AddRange(Conditions);

            dbContext.SaveChanges();
        }
    }
}
