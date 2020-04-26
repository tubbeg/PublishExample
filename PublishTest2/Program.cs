using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PublishTest2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    var assemblyFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    var binDirectory = System.IO.Path.GetDirectoryName(assemblyFilePath);
                    webBuilder.UseContentRoot(binDirectory);
                    webBuilder.UseWebRoot("wwwroot");
                });
    }
}
