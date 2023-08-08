

using WatchHeaven.Data.Model;
using WatchHeaven.Web.Data;

namespace WatchHeaven.Services.Tests
{
    public static class DbSeeder
    {
        public static ApplicationUser SellerUser;
        public static Seller Seller;

        public static void SeedDb(WatchHeavenDbContext dbContext)
        {
            SellerUser = new ApplicationUser()
            {
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
                PhoneNumber = "+359444444444",
                Address = "Some random address 1",
                User = SellerUser,
            };

            dbContext.Users.Add(SellerUser);
            dbContext.Sellers.Add(Seller);

            dbContext.SaveChanges();
        }
    }
}
