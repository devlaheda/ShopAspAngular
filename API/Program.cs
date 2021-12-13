using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var Host =  CreateHostBuilder(args).Build();
           using (var scope = Host.Services.CreateScope())
           {
                var Services = scope.ServiceProvider;
                var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                     var context = Services.GetRequiredService<ShopContext>();
                     await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {                    
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex,"Error during migration , Please check log");
                }
           }
           Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
