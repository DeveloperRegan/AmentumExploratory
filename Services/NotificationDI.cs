namespace AmentumExploratory.Services;

public sealed record NotificationServiceType
{
    public const string UI = "UI";
    public const string Text = "Text";
}

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
                NotificationServiceType.UI => serviceProvider.GetRequiredService<UINotificationService>(),
                NotificationServiceType.Text => serviceProvider.GetRequiredService<TextFileNotificationService>(),
                _ => throw new ArgumentException("Invalid notification type", nameof(key))
            };
        });

        return services;
    }
}
