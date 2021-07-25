using FengShui.Service;
using FengShui.Service.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FengShuiNumbers
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            try
            {
                var configuration = (IConfiguration)host.Services.GetService(typeof(IConfiguration));
                FengShuiNumberConfiguration config = new FengShuiNumberConfiguration();
                configuration.GetSection("FengShuiPattern").Bind(config);

                var numberService = (INumberService)host.Services.GetService(typeof(INumberService));
                var fengShuiNumbers = numberService.GetFengShui(config);

                if(fengShuiNumbers.Count > 0)
                {
                    Console.Write("Feng shui numbers: ");
                    foreach (var item in fengShuiNumbers)
                    {
                        Console.Write(item.Number);
                        Console.Write("\t");
                    }
                }
                else
                {
                    Console.WriteLine("Can not find feng shui numbers");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!");
            }

            Console.ReadKey();
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                    IConfigurationRoot configurationRoot = configuration.Build();
                })
                .ConfigureServices((context, services) =>
                    services.AddCustomConfigures(context.Configuration));
    }
}
