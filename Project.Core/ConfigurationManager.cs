using Microsoft.Extensions.Configuration;
using Project.Core.Models;

namespace Project.Core;

public static class ConfigurationManager
{
    public static IConfiguration configuration;
    private static BrowserSettings browserSettings;
    private static ApiSettings apiSettings;

    static ConfigurationManager()
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("logging.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }

    public static BrowserSettings GetBrowserSettings()
    {
        browserSettings = new BrowserSettings(
            configuration["AppConfig:BaseURL"]!,
            configuration["AppConfig:Browser"]!);
        
        return browserSettings;
    }

    public static ApiSettings GetApiSettings()
    {
        apiSettings = new ApiSettings(
            int.Parse(configuration["APIConfig:Timeout"]!),
            configuration["APIConfig:BaseApiURL"]!);

        return apiSettings;
    }
}
