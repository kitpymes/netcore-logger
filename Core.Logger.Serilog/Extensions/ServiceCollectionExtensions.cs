﻿using Core.Logger.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Core.Logger.Serilog
{
    public static class ServiceCollectionExtensions
    {
        public static ILoggerService LoadSerilog
        (
            this IServiceCollection services,

            SerilogSettings settings
        )
        {
            services.TryAddSingleton<ILoggerService>(new SerilogProvider(settings));

            return services.BuildServiceProvider().GetService<ILoggerService>();
        }

        public static ILoggerService LoadSerilog
        (
            this IServiceCollection services,

            Action<SerilogSettings> settings
        )
        => services.LoadSerilog(settings.ConfigureOrDefault());
    }
}
