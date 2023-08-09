using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data;
using WatchHeaven.Web.Data;
using static WatchHeaven.Services.Tests.DbSeeder;
using WatchHeaven.Web.ViewModels.Home;
using WatchHeaven.Web.ViewModels.Watch;
using WatchHeaven.Web.ViewModels.Watch.Enums;
using WatchHeaven.Data.Model;
using static WatchHeaven.Common.EntityValidationConstants;

namespace WatchHeaven.Services.Tests
{
    public class WatchServiceTest
    {
        private DbContextOptions<WatchHeavenDbContext> dbContextOptions;
        private WatchHeavenDbContext dbContext;
        private IWatchService watchService;

        [SetUp]
        public void OneTimeSetUp()
        {
            this.dbContextOptions = new DbContextOptionsBuilder<WatchHeavenDbContext>()
                .UseInMemoryDatabase("WatchHeavenInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new WatchHeavenDbContext(this.dbContextOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDb(this.dbContext);

            this.watchService = new WatchService(this.dbContext);
        }

        [Test]
        public async Task MostExpensiveWatchesAsyncShouldReturnTheFourMostExpensiveWatches()
        {
            IEnumerable<IndexViewModel> mostExpensiveWatches = await this.watchService.MostExpensiveWatchesAsync();
            Assert.AreEqual(2, mostExpensiveWatches.Count());
        }

        [Test]
        public async Task TheFirstWatchShouldBeTheMostExpensiveOne()
        {
            IEnumerable<IndexViewModel> mostExpensiveWatches = await this.watchService.MostExpensiveWatchesAsync();
            bool result = mostExpensiveWatches.First().Id.ToString() == "b4249945-b9d9-4a26-82a0-b5bbc30d20f4";
            //The price of this watch is 2550.00 and the other one is 550.00
            Assert.IsTrue(result);
        }

        [Test]
        public async Task TheFirstWatchShouldReturnFalseIfTheFirstIsNotTheMostExpensiveOne()
        {
            IEnumerable<IndexViewModel> mostExpensiveWatches = await this.watchService.MostExpensiveWatchesAsync();
            bool result = mostExpensiveWatches.First().Id.ToString() == "86080918-9815-408d-8261-8a0fbf6350a3";
            //The price of this watch is 550.00 and the other one is 2550.00
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateWatchShouldAddWatchToTheDatabase()
        {
            string sellerId = "c1ff0048-2c60-45bf-a111-123405281b43";
            WatchFormViewModel watch = new WatchFormViewModel()
            {
                Brand = "RandomBrand",
                Model = "RandomModel",
                Description = "Somew random description for the test",
                ImageUrl = "RandomUrl",
                Price = 1000.00m,
                CategoryId = 3,
                ConditionId = 3
            };

            string createdWatchId = await this.watchService.CreateAsync(watch, sellerId);

            bool result = await this.dbContext.Watches.AnyAsync(w => w.Id.ToString() == createdWatchId);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CreateWatchShouldBeFalseIfTheIdIsIncorrect()
        {
            string sellerId = "c1ff0048-2c60-45bf-a111-123405281b43";
            WatchFormViewModel watch = new WatchFormViewModel()
            {
                Brand = "RandomBrand",
                Model = "RandomModel",
                Description = "Somew random description for the test",
                ImageUrl = "RandomUrl",
                Price = 1000.00m,
                CategoryId = 3,
                ConditionId = 3
            };

            string createdWatchId = await this.watchService.CreateAsync(watch, sellerId);

            string nonExistingWatchId = "4cbfac24-dcc4-47f4-8556-53da74e5d0f8";
            Assert.AreNotEqual(createdWatchId, nonExistingWatchId);
        }

        [Test]
        public async Task AllAsyncShouldReturnAllWatchesFilteredAndSorted()
        {
            var queryModel = new AllWatchesQueryModel
            {
                CurrentPage = 1,
                WatchesPerPage = 2,
                WatchSorting = WatchSorting.Newest
            };

            var result = await watchService.AllAsync(queryModel);

            Assert.NotNull(result);
        }

        [Test]
        public async Task AllBySellerIdAsyncShouldReturnAllTheWatchesFormSeller()
        {
            var sellerId = "c1ff0048-2c60-45bf-a111-123405281b43";

            var result = await watchService.AllBySellerIdAsync(sellerId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());

            var firstWatch = result.First();
            Assert.AreEqual("Test brand", firstWatch.Brand);
            Assert.AreEqual("Test model", firstWatch.Model);
            Assert.AreEqual(550.00M, firstWatch.Price);
            Assert.AreEqual("randomImgUrl", firstWatch.ImageUrl);

            var secondWatch = result.Skip(1).First();
            Assert.AreEqual("Test brand 2", secondWatch.Brand);
            Assert.AreEqual("Test model 2", secondWatch.Model);
            Assert.AreEqual(2550.00M, secondWatch.Price);
            Assert.AreEqual("randomImgUrl2", secondWatch.ImageUrl);
        }

        [Test]
        public async Task AllBySellerIdAsyncShouldReturnNoWatchesForInvalidSellerId()
        {
            var invalidSellerId = "invalid-seller-id";

            var result = await watchService.AllBySellerIdAsync(invalidSellerId);

            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetDetailsByWatchIdShouldReturnTheDetailsIfIdIsCorrect()
        {
            string watchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            var result = await watchService.GetDetailsByIdAsync(watchId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(watchId.ToString(), result.Id);
            Assert.AreEqual("Test brand", result.Brand);
            Assert.AreEqual("Test model", result.Model);
            Assert.AreEqual("A really cool watch for testing", result.Description);
            Assert.AreEqual(550.00m, result.Price);
            Assert.AreEqual("randomImgUrl", result.ImageUrl);
            Assert.AreEqual("Vintage", result.Category);
            Assert.AreEqual("New", result.Condition);
            Assert.NotNull(result.Seller);
            Assert.AreEqual("seller@seller.com", result.Seller.Email);
            Assert.AreEqual("+359444444444", result.Seller.PhoneNumber);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenWatchExists()
        {
            string existingWatchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            bool result = await watchService.ExistsByIdAsync(existingWatchId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenWatchDoesNotExist()
        {
            string nonExistingWatchId = "nonExistingId";

            bool result = await watchService.ExistsByIdAsync(nonExistingWatchId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetWatchForDeleteByIdAsyncShouldReturnWatchDetailsWhenWatchExists()
        {
            string existingWatchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            var result = await watchService.GetWatchForDeleteByIdAsync(existingWatchId);

            Assert.NotNull(result);
            Assert.AreEqual("Test brand", result.Brand);
            Assert.AreEqual("Test model", result.Model);
            Assert.AreEqual("randomImgUrl", result.ImageUrl);
        }

        [Test]
        public async Task GetWatchForEditByIdAsyncShouldReturnWatchForEditWhenWatchExists()
        {
            string existingWatchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            var result = await watchService.GetWatchForEditByIdAsync(existingWatchId);

            Assert.NotNull(result);
            Assert.AreEqual("Test brand", result.Brand);
            Assert.AreEqual("Test model", result.Model);
            Assert.AreEqual("randomImgUrl", result.ImageUrl);
            Assert.AreEqual(550.00m, result.Price);
            Assert.AreEqual("A really cool watch for testing", result.Description);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(1, result.ConditionId);
            Assert.NotNull(result.Categories);
            Assert.NotNull(result.Conditions);
        }


        [Test]
        public async Task IsSellerWithIdOwnerofWatchWithIdAsyncShouldReturnTrueWhenSellerIsOwner()
        {
            string sellerId = "c1ff0048-2c60-45bf-a111-123405281b43";
            string watchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            var result = await watchService.IsSellerWithIdOwnerofWatchWithIdAsync(sellerId, watchId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditWatchByIdAndFormModelAsyncShouldUpdateWatchPropertiesWhenValidDataProvided()
        {
            // Arrange
            string watchId = "86080918-9815-408d-8261-8a0fbf6350a3";
            var formModel = new WatchFormViewModel
            {
                Brand = "Updated Brand",
                Model = "Updated Model",
                Description = "Updated Description",
                ImageUrl = "updatedImageUrl",
                Price = 999.99M,
                CategoryId = 2,
                ConditionId = 2
            };

            // Act
            await watchService.EditWatchByIdAndFormModelAsync(watchId, formModel);

            // Assert
            var updatedWatch = await dbContext.Watches.FindAsync(Guid.Parse(watchId));
            Assert.NotNull(updatedWatch);
            Assert.AreEqual(formModel.Brand, updatedWatch.Brand);
            Assert.AreEqual(formModel.Model, updatedWatch.Model);
            Assert.AreEqual(formModel.Description, updatedWatch.Description);
            Assert.AreEqual(formModel.ImageUrl, updatedWatch.ImageUrl);
            Assert.AreEqual(formModel.Price, updatedWatch.Price);
            Assert.AreEqual(formModel.CategoryId, updatedWatch.CategoryId);
            Assert.AreEqual(formModel.ConditionId, updatedWatch.ConditionId);
        }

        [Test]
        public async Task EditWatchByIdAndFormModelAsyncShouldNotUpdateWatchWhenInvalidIdProvided()
        {
            // Arrange
            string watchId = "non-existent-id";
            var formModel = new WatchFormViewModel
            {
                Brand = "Updated Brand",
                Model = "Updated Model",
                Description = "Updated Description",
                ImageUrl = "updatedImageUrl",
                Price = 999.99M,
                CategoryId = 2,
                ConditionId = 2
            };

            // Act and Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await watchService.EditWatchByIdAndFormModelAsync(watchId, formModel);
            });
        }

        [Test]
        public async Task DeleteWatchByIdAsyncShouldDeactivateWatch()
        {
            var watchId = "86080918-9815-408d-8261-8a0fbf6350a3";
            var watch = await dbContext.Watches.FindAsync(Guid.Parse(watchId));

            await watchService.DeleteWatchByIdAsync(watchId);
            var isWatchActive = watch.IsActive;

            Assert.IsFalse(isWatchActive);
        }

        [Test]
        public async Task GetStatisticsAsyncShouldReturnCorrectStatistics()
        {
            var expectedTotalWatches = dbContext.Watches.Count();
            var expectedTotalUsers = dbContext.Users.Count();

            var result = await watchService.GetStatisticsAsync();

            Assert.NotNull(result);
            Assert.AreEqual(expectedTotalWatches, result.TotalWatches);
            Assert.AreEqual(expectedTotalUsers, result.TotalUsers);
        }

        [Test]
        public async Task GetWatchInfoByWatchIdAsyncShouldReturnWatchInfo()
        {
            string watchId = "86080918-9815-408d-8261-8a0fbf6350a3";

            var result = await watchService.GetWatchInfoByWatchIdAsync(watchId);

            Assert.NotNull(result);
            Assert.AreEqual(watchId, result.Id);
            Assert.AreEqual("Test brand", result.Brand);
            Assert.AreEqual("Test model", result.Model);
            Assert.AreEqual("randomImgUrl", result.ImageUrl);
            Assert.AreEqual(550.00M, result.Price);
        }

    }
}
