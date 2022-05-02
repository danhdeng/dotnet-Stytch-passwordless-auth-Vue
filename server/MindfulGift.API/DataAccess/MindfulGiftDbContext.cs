using Microsoft.EntityFrameworkCore;
using MindfulGift.API.Models;

namespace MindfulGift.API.DataAccess
{
    public class MindfulGiftDbContext : DbContext
    {
        public MindfulGiftDbContext() { }

        public MindfulGiftDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<AppUser>  AppUsers{get; set;}

    }
}
