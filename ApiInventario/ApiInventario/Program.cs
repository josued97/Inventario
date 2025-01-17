using System.Reflection;
using ApiInventario.Configure;
using Application.Dtos;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            //builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            //}
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CrearClienteDto).Assembly));

            builder.Services.AddDbContext<Context>(opt =>
            {
                opt.UseInMemoryDatabase("PruebaInventario");
            });

            // Agregar servicios del mi aplicacion
            builder.Services.AddAppConfig();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
