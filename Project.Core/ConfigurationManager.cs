using Microsoft.Extensions.Configuration;

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
        return new(
            configuration["baseUrl"]!,
            configuration["browser"]!
        );
    }
}
