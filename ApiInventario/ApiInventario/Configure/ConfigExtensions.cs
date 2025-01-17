using System.Runtime.CompilerServices;
using Application.Injections;

namespace ApiInventario.Configure;

/// <summary>
/// Crear contenedor de dependencias
/// </summary>
public static class ConfigExtensions
{
    /// <summary>
    /// Inyectar instancias de servicios (aplicación y dominio)
    /// </summary>
    public static IServiceCollection AddAppConfig(this IServiceCollection services)
    {
        services.AddContainer();

        return services;
    }
}
