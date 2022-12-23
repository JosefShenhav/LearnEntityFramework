using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using postgres_docker.Data;
using postgres_docker.Models;

namespace postgres_docker
{
    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _lifetime;
        private readonly ApiDbContext _apiDbContext;

        public Worker(IHostApplicationLifetime lifetime, ApiDbContext apiDbContext)
        {
            _lifetime = lifetime;
            _apiDbContext = apiDbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _apiDbContext.yosef.AddRangeAsync(new yosef
            {
                age = 12,
                designation = "SAD",
                name = "Lord2",
                salary = 123
            }, new yosef
            {
                age = 12,
                designation = "SAD",
                name = "Lport",
                salary = 123
            });
            
            await _apiDbContext.SaveChangesAsync(stoppingToken);
            
            _lifetime.StopApplication();
        }
    }
}