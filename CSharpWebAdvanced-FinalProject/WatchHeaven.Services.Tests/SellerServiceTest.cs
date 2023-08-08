using Microsoft.EntityFrameworkCore;
using WatchHeaven.Services.Data;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
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
        public async Task SellerExistsByUserIdAsyncShouldReturnTrueIfTheSellerExists()
        {
            string existingSellerUserId = SellerUser.Id.ToString();

            bool result = await this.sellerService.SellerExistsByUserIdAsync(existingSellerUserId);

            Assert.IsTrue(result);
        }
    }
}