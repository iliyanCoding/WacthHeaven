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
using WatchHeaven.Web.ViewModels.Category;

namespace WatchHeaven.Services.Tests
{
    public class CategoryServiceTest
    {
        private DbContextOptions<WatchHeavenDbContext> dbContextOptions;
        private WatchHeavenDbContext dbContext;
        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContextOptions = new DbContextOptionsBuilder<WatchHeavenDbContext>()
                .UseInMemoryDatabase("WatchHeavenInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new WatchHeavenDbContext(this.dbContextOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDb(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldReturnAllCategories()
        {
            IEnumerable<WatchSelectCategoryFormModel> result = await this.categoryService.GetAllCategoriesAsync();

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldReturnFalseIfIncorrect()
        {
            IEnumerable<WatchSelectCategoryFormModel> result = await this.categoryService.GetAllCategoriesAsync();

            Assert.AreNotEqual(2, result.Count());
        }

        [Test]
        public async Task CategoryExistsByIdAsyncShouldReturnTrueIfCorrect()
        {
            int expectedCategoryId = Categories.First().Id;
            bool result = await this.categoryService.ExistsByIdAsync(expectedCategoryId);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CategoryExistsByIdAsyncShouldReturnFalseIfIncorrect()
        {
            int expectedCategoryId = 5;
            bool result = await this.categoryService.ExistsByIdAsync(expectedCategoryId);
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllCategoriesNameAsyncShouldReturnFalseIfIncorrect()
        {
            IEnumerable<string> expectedCategories = new List<string>() { "Vintage", "Pilot's"};
            IEnumerable<string> actualResult = await this.categoryService.AllCategoriesNamesAsync();
            CollectionAssert.AreNotEqual(expectedCategories, actualResult);
        }

        [Test]
        public async Task AllCategoriesNameAsyncShouldReturnTrueIfCorrect()
        {
            IEnumerable<string> expectedCategories = new List<string>() { "Vintage", "Pilot's", "Diving" };
            IEnumerable<string> actualResult = await this.categoryService.AllCategoriesNamesAsync();
            CollectionAssert.AreEqual(expectedCategories, actualResult);
        }
    }
}
