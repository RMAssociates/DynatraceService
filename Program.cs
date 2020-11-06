using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynatraceService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DynatraceService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //Log.Logger = new LoggerConfiguration()
            //.Enrich.FromLogContext()
            //.WriteTo.File()
            //.CreateLogger();

            //try
            //{
            //    Log.Information("Starting up");
            //    CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Application start-up failed");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                              //  .UseSerilog() // https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/
                    .UseSerilog((hostingContext, loggerConfig) =>
                    loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
                )
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ServiceA>();
                    services.AddHostedService<ServiceB>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>();
                });
    }
}
