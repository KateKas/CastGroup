using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CastGroup.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup));
        }
    }
}
