using Microsoft.EntityFrameworkCore;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data;
using WatchHeaven.Web.Data;
using static WatchHeaven.Services.Tests.DbSeeder;
using WatchHeaven.Web.ViewModels.User;

namespace WatchHeaven.Services.Tests
{
    public class UserServiceTest
    {
        private DbContextOptions<WatchHeavenDbContext> dbContextOptions;
        private WatchHeavenDbContext dbContext;
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContextOptions = new DbContextOptionsBuilder<WatchHeavenDbContext>()
                .UseInMemoryDatabase("WatchHeavenInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new WatchHeavenDbContext(this.dbContextOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDb(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        [Test]
        public async Task GetFullNameAsyncShouldReturnTrueIfCorrect()
        {
            string actualUserName = SellerUser.FirstName + " " + SellerUser.LastName;
            string expectedUserName = await this.userService.GetFullNameAsync(SellerUser.Email);
            Assert.AreEqual(expectedUserName, actualUserName);
        }

        [Test]
        public async Task GetFullNameAsyncShouldReturnFalseIfIncorrect()
        {
            string actualUserName = "Wrong FullName";
            string expectedUserName = await this.userService.GetFullNameAsync(SellerUser.Email);
            Assert.AreNotEqual(expectedUserName, actualUserName);
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnTrueIfCorrect()
        {
            string actualUserName = SellerUser.FirstName + " " + SellerUser.LastName;
            string expectedUserName = await this.userService.GetFullNameByIdAsync(SellerUser.Id.ToString());
            Assert.AreEqual(expectedUserName, actualUserName);
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldReturnFalseIfIncorrect()
        {
            string actualUserName = "Wrong FullName";
            string expectedUserName = await this.userService.GetFullNameByIdAsync(SellerUser.Id.ToString());
            Assert.AreNotEqual(expectedUserName, actualUserName);
        }

        [Test]
        public async Task GetAllUsersAsyncShoulldReturnTrueIfCorrect()
        {
            IEnumerable<UserViewModel> result = await this.userService.GetAllUsersAsync();

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task GetAllUsersAsyncShoulldReturnFalseIfIncorrect()
        {
            IEnumerable<UserViewModel> result = await this.userService.GetAllUsersAsync();

            Assert.AreNotEqual(2, result.Count());
        }
    }
}
