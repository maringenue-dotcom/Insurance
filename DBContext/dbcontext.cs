using API.DBModels;
using Microsoft.EntityFrameworkCore;

namespace API.DBContext
{

    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options) { }


        public DbSet<Campus> Campus { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
