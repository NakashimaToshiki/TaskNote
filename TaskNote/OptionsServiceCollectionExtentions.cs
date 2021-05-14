using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote
{
    public static class OptionsServiceCollectionExtentions
    {
        public static IServiceCollection AddOptions(this IServiceCollection services)
        {
            return services
                .AddSingleton<UserOptions>()
                .AddSingleton<IUserOptions>(_ => _.GetRequiredService<UserOptions>())
                ;
        }

        public static IServiceCollection AddMockDatetimeOptions(this IServiceCollection services) =>
            services.AddStopwatchDatetimeOptions(DateTime.Parse("2000-01-01 01:01:01"));

        public static IServiceCollection AddStopwatchDatetimeOptions(this IServiceCollection services, DateTime Offset)
        {
            var options = new StopwatchDatetimeOptions()
            {
                Offset = Offset
            };
            return services
                .AddSingleton<StopwatchDatetimeOptions>(options)
                .AddSingleton<IDateTimeOptions>(_ => _.GetRequiredService<StopwatchDatetimeOptions>())
                ;
        }
    }
}
