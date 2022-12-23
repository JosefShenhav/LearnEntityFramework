using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using postgres_docker.Models;

namespace postgres_docker.Data
{
    public class ApiDbContext : DbContext
    { 
        protected readonly IConfiguration Configuration;

        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<yosef> yosef { get; set; }

    }
}