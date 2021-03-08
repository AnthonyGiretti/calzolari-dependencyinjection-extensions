using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Calzolari.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void Unregister<TService>(this IServiceCollection services)
        {
            var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(TService));
            services.Remove(descriptor);
        }

        public static void Replace<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
        {
            services.Unregister<TService>();
            services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime));
        }

        public static void ReplaceScoped<TService, TImplementation>(this IServiceCollection services) where TService : class
            where TImplementation : class, TService
        {
            services.Unregister<TService>();
            services.AddScoped<TService, TImplementation>();
        }

        public static void ReplaceTransient<TService, TImplementation>(this IServiceCollection services) where TService : class
            where TImplementation : class, TService
        {
            services.Unregister<TService>();
            services.AddTransient<TService, TImplementation>();
        }

        public static void ReplaceSingleton<TService, TImplementation>(this IServiceCollection services) where TService : class
            where TImplementation : class, TService
        {
            services.Unregister<TService>();
            services.AddSingleton<TService, TImplementation>();
        }
    }
}