﻿using Microsoft.Extensions.Configuration;

namespace Project.Core.Settings;

public static class ConfigurationManager
{
    public static readonly IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("loggerConfiguration.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    private static BrowserSettings? browserSettings;
    private static ApiSettings? apiSettings;
    private static UserCredentials? userCredentials;

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

    public static UserCredentials GetUserCredentials()
    {
        userCredentials ??= configuration.GetRequiredSection("UserCredentials").Get<UserCredentials>()!;
        return userCredentials;
    }
}
