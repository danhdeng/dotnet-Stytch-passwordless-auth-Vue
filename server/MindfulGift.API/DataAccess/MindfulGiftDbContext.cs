using Microsoft.EntityFrameworkCore;

namespace MindfulGift.API.DataAccess
{
    public class MindfulGiftDbContext : DbContext
    {
        public MindfulGiftDbContext() { }

        public MindfulGiftDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<AppUser>  AppUsers{get; set;}

    }
}
