using Domain.Interfaces;
using Infraestructure.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Injections
{
    /// <summary>
    /// Crear contenedor de dependencias
    /// </summary>
    public static class ReposContainerExtensions
    {
        /// <summary>
        /// Inyectar instancias de repositorios del proyecto
        /// </summary>
        public static IServiceCollection AddReposContainer(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();

            return services;
        }
    }
}
