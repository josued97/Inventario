using Microsoft.Extensions.DependencyInjection;

namespace Application.Injections
{
    /// <summary>
    /// Contenedor de dependencias
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Agregar contenedor de dependencias para el proyecto
        /// </summary>
        public static IServiceCollection AddContainer(this IServiceCollection services)
        {
            services.AddCommonContainer();
            services.AddReposContainer();
            services.AddServicesContainer();

            return services;
        }
    }
}
