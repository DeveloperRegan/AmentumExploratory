namespace AmentumExploratory.Services;


public static class NotificationDI
{
    public static IServiceCollection AddNotificationServices(this IServiceCollection services)
    {
        services.AddTransient<UINotificationService>();
        services.AddTransient<TextFileNotificationService>();

        services.AddTransient<Func<string, INotificationService>>(serviceProvider => key =>
        {
            return key switch
            {
                "UI" => serviceProvider.GetRequiredService<UINotificationService>(),
                "Text" => serviceProvider.GetRequiredService<TextFileNotificationService>(),
                _ => throw new ArgumentException("Invalid notification type", nameof(key))
            };
        });

        return services;
    }
}


