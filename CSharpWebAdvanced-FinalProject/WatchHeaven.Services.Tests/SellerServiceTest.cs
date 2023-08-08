using Microsoft.EntityFrameworkCore;
using WatchHeaven.Services.Data;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Seller;
using static WatchHeaven.Services.Tests.DbSeeder;

namespace WatchHeaven.Services.Tests
{
    public class SellerServiceTest
    {
        private DbContextOptions<WatchHeavenDbContext> dbContextOptions;
        private WatchHeavenDbContext dbContext;
        private ISellerService sellerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContextOptions = new DbContextOptionsBuilder<WatchHeavenDbContext>()
                .UseInMemoryDatabase("WatchHeavenInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new WatchHeavenDbContext(this.dbContextOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDb(this.dbContext);

            this.sellerService = new SellerService(this.dbContext);
        }

        [Test]
        public async Task SellerExistsByUserIdAsyncShouldReturnTrueIfTheSellerExist()
        {
            string existingSellerUserId = SellerUser.Id.ToString();

            bool result = await this.sellerService.SellerExistsByUserIdAsync(existingSellerUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task SellerExistsByUserIdAsyncShouldReturnFalseIfTheSellerDoesNotExist()
        {
            string nonExistingSellerUserId = "ab4e46db-56f1-4f8a-ad4e-1ac21bb6f306";

            bool result = await this.sellerService.SellerExistsByUserIdAsync(nonExistingSellerUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SellerExistsByPhoneNumberAsyncShouldReturnTrueIfSellerExists()
        {
            string existingSellerUserPhoneNumber = Seller.PhoneNumber;

            bool result = await this.sellerService.SellerExistsByPhoneNumberAsync(existingSellerUserPhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task SellerExistsByPhoneNumberAsyncShouldReturnFalseIfSellerDoesNotExist()
        {
            string nonExistingSellerUserPhoneNumber = "+359565656565";

            bool result = await this.sellerService.SellerExistsByPhoneNumberAsync(nonExistingSellerUserPhoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SellerExistsByAddressAsyncShouldReturnTrueIfSellerExist()
        {
            string existingSellerAddress = Seller.Address;

            bool result = await this.sellerService.SellerExistsByAddressAsync(existingSellerAddress);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task SellerExistsByAddressAsyncShouldReturnFalseIfSellerDoesNotExist()
        {
            string nonExistingSellerAddress = "Invalid address";

            bool result = await this.sellerService.SellerExistsByAddressAsync(nonExistingSellerAddress);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateSellerAsyncShouldAddSellerToDatabase()
        {
            string userId = "3bcb1c87-e7fe-4d30-a4fd-620c3619b18f";
            var model = new BecomeSellerFormModel
            {
                PhoneNumber = "1234567890",
                Address = "123 Main St"
            };

            await this.sellerService.CreateSellerAsync(userId, model);

            var createdSeller = await this.dbContext.Sellers.FirstOrDefaultAsync(s => s.UserId == Guid.Parse(userId));

            Assert.NotNull(createdSeller); 
            Assert.AreEqual(model.PhoneNumber, createdSeller.PhoneNumber);
            Assert.AreEqual(model.Address, createdSeller.Address);
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncShouldReturnTrueIfCorrect()
        {
            string existingSellerUserId = SellerUser.Id.ToString();

            string actualSellerId = Seller.Id.ToString();
            string expectedSellerId = await this.sellerService.GetSellerIdByUserIdAsync(existingSellerUserId);

            Assert.AreEqual(expectedSellerId, actualSellerId);
        }

        [Test]
        public async Task GetSellerIdByUserIdAsyncShouldReturnFalseIfIncorect()
        {
            string existingSellerUserId = SellerUser.Id.ToString();

            string actualSellerId = Guid.NewGuid().ToString();
            string expectedSellerId = await this.sellerService.GetSellerIdByUserIdAsync(existingSellerUserId);

            Assert.AreNotEqual(expectedSellerId, actualSellerId);
        }

        [Test]
        public async Task HasWatchWithIdAsyncShouldReturnTrueIfWatchExists()
        {
            string userId = SellerUser.Id.ToString();
            string watchId = Watch.Id.ToString();

            bool result = await this.sellerService.HasWatchWithIdAsync(userId, watchId);

            Assert.IsTrue(result);

        }

        [Test]
        public async Task HasWaHasWatchWithIdAsyncShouldReturnFalseIfuserIdIsIncorrect()
        {
            string userId = Seller.Id.ToString();
            string watchId = Watch.Id.ToString();

            bool result = await this.sellerService.HasWatchWithIdAsync(userId, watchId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasWaHasWatchWithIdAsyncShouldReturnFalseIfWatchIdIsIncorrect()
        {
            string userId = Seller.Id.ToString();
            string watchId = Guid.NewGuid().ToString();

            bool result = await this.sellerService.HasWatchWithIdAsync(userId, watchId);

            Assert.IsFalse(result);
        }
    }
}