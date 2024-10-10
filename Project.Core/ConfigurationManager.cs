using Microsoft.Extensions.Configuration;
using Project.Core.Models;

namespace Project.Core;

public class ConfigurationManager
{
    private readonly IConfiguration configuration;

    public ConfigurationManager()
    {
        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
    }

    public Configuration Get()
    {
        var appConfig = new AppConfig(
            configuration["AppConfig:baseURL"]!,
            configuration["AppConfig:browser"]!
        );

        var apiSettings = new ApiSettings(
            int.Parse(configuration["APIConfig:timeout"]!),
            configuration["APIConfig:URL"]!
        );

        return new Configuration(appConfig, apiSettings);

    }
}
