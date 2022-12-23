using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using postgres_docker.Data;

namespace postgres_docker
{
    public static class Program
    {
        private const string DEFAULT_APPSETTINGS_FILE_PATH = "appsettings.json";

        public static async Task Main()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(DEFAULT_APPSETTINGS_FILE_PATH).Build();
            
            var host = Host.CreateDefaultBuilder().ConfigureServices(collection =>
            {
                collection.AddHostedService<Worker>();

                collection.AddDbContext<ApiDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("ConnectionStrings"));
                });
            });

            await host.Build().RunAsync();
        }
    }
}