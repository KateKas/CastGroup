using System;
using CastGroup.Data.Repositories;
using CastGroup.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CastGroup.Config
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        }
    }
}
