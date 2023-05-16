using Microsoft.EntityFrameworkCore;

namespace WorkOne.DbAccess
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DbConString"));
        }

        public DbSet<Domain.AppUser> AppUsers { get; set; }
    }
}
