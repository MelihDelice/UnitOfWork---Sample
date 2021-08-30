using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PocketBook
{
    public class Program
    {
        public readonly IConfiguration _configuration;
        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
            var x = _configuration.GetSection("GreetingMessage");
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(x);
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
