
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;

namespace WatchHeaven.Services.Data
{
    public class WatchService : IWatchService
    {
        private readonly WatchHeavenDbContext dbContext;

        public WatchService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
