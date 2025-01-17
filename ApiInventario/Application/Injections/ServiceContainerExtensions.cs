using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Injections;

/// <summary>
/// Crear contenedor de dependencias
/// </summary>
public static class ServiceContainerExtensions
{
    /// <summary>
    /// Inyecta instancias de servicios del proyecto
    /// </summary>
    public static IServiceCollection AddServicesContainer(this IServiceCollection services)
    {
        // Servicios de dominio
        services.AddTransient<IClienteService, ClienteService>();
        services.AddTransient<IProductoService, ProductoService>();

        return services;
    }
}
