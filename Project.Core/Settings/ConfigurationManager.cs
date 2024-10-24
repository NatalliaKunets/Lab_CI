using Microsoft.Extensions.Configuration;

namespace Project.Core.Settings;

public static class ConfigurationManager
{
    public static readonly IConfiguration configuration;
    private static BrowserSettings? browserSettings;
    private static ApiSettings? apiSettings;

    static ConfigurationManager()
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("loggerConfiguration.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }

    public static BrowserSettings GetBrowserSettings()
    {
        browserSettings ??= configuration.GetRequiredSection("AppConfig").Get<BrowserSettings>()!;
        return browserSettings;
    }

    public static ApiSettings GetApiSettings()
    {
        apiSettings ??= configuration.GetRequiredSection("APIConfig").Get<ApiSettings>()!;
        return apiSettings;
    }
}
