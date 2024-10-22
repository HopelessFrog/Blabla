using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Core.ServicesProvider
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            return services.AddLogging(loggingBuilder =>
             {
                 loggingBuilder.ClearProviders();
                 loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                 loggingBuilder.AddNLog("nlog.config");
             });
        }

        public static IServiceCollection AddLoggerScope<T>(this IServiceCollection services)
        {
            return services.AddScoped<ILogger>(s => s.GetRequiredService<ILogger<T>>());
        }
    }
}
