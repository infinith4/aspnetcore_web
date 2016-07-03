using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using EmptyWebApplication.Models;

namespace EmptyWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
           TodoItem todoItem = new TodoItem();
           todoItem.Key = "key";
           todoItem.Name = "name";
           todoItem.IsComplete = true;
           
           var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
            
            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
