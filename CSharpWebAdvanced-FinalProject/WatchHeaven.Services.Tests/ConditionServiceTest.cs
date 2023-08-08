using Microsoft.EntityFrameworkCore;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data;
using WatchHeaven.Web.Data;
using static WatchHeaven.Services.Tests.DbSeeder;
using WatchHeaven.Web.ViewModels.Condition;

namespace WatchHeaven.Services.Tests
{
    public class ConditionServiceTest
    {
        private DbContextOptions<WatchHeavenDbContext> dbContextOptions;
        private WatchHeavenDbContext dbContext;
        private IConditionService conditionService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContextOptions = new DbContextOptionsBuilder<WatchHeavenDbContext>()
                .UseInMemoryDatabase("WatchHeavenInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new WatchHeavenDbContext(this.dbContextOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDb(this.dbContext);

            this.conditionService = new ConditionService(this.dbContext);
        }

        [Test]
        public async Task GetAllConditionsAsyncShouldReturnAllConditions()
        {
            IEnumerable<WatchSelectConditionFormModel> result = await this.conditionService.GetAllConditionsAsync();

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetAllConditionsAsyncShouldReturnFalseIfIncorrect()
        {
            IEnumerable<WatchSelectConditionFormModel> result = await this.conditionService.GetAllConditionsAsync();

            Assert.AreNotEqual(2, result.Count());
        }

        [Test]
        public async Task ConditionExistsByIdAsyncShouldReturnTrueIfCorrect()
        {
            int expectedConditionId = Conditions.First().Id;
            bool result = await this.conditionService.ExistsByIdAsync(expectedConditionId);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ConditionExistsByIdAsyncShouldReturnFalseIfIncorrect()
        {
            int expectedConditionId = 5;
            bool result = await this.conditionService.ExistsByIdAsync(expectedConditionId);
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllConditionsNameAsyncShouldReturnFalseIfIncorrect()
        {
            IEnumerable<string> expectedConditions = new List<string>() { "New", "Very Good" };
            IEnumerable<string> actualResult = await this.conditionService.AllConditionsNamesAsync();
            CollectionAssert.AreNotEqual(expectedConditions, actualResult);
        }

        [Test]
        public async Task AllConditionsNameAsyncShouldReturnTrueIfCorrect()
        {
            IEnumerable<string> expectedConditions = new List<string>() { "New", "Very Good", "Fair" };
            IEnumerable<string> actualResult = await this.conditionService.AllConditionsNamesAsync();
            CollectionAssert.AreEqual(expectedConditions, actualResult);
        }
    }
}
