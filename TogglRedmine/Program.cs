using ILogger = Microsoft.Extensions.Logging.ILogger;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using TogglRedmine.Clients;
using TogglRedmine.Configuration;
using TogglRedmine.Extensions;
using TogglRedmine.Model.Redmine;

namespace TogglRedmine
{
    class Program
    {
        private static ILogger _logger;
        public static Settings Settings { get; set; } = new Settings();

        static void Main(string[] args)
        {
            // configure service provider
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // locate app & run
            serviceProvider.GetService<App>().Run();   
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole());

            serviceCollection.AddLogging(); 

            // add configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<RedmineSettings>(configuration.GetSection("RedmineSettings"));
            serviceCollection.Configure<TogglSettings>(configuration.GetSection("TogglSettings"));
            serviceCollection.Configure<Dictionary<string,int>>(configuration.GetSection("ProjectNameMapping"));

            // add clients
            serviceCollection.AddTransient<IRedmineClient, RedmineClient>();
            serviceCollection.AddTransient<ITogglClient, TogglClient>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}