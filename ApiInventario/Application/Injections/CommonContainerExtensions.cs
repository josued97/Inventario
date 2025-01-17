using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utilities;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Injections
{
    /// <summary>
    /// Contenedor de dependencias
    /// </summary>
    public static class CommonContainerExtensions
    {
        /// <summary>
        /// Inyectar instancias de uso común
        /// </summary>
        public static IServiceCollection AddCommonContainer(this IServiceCollection services)
        {

            services.AddTransient<IErrorHandler, ErrorHandler>();

            //Context
            services.AddTransient<IContext, Context>();



            return services;
        }
    }
}
