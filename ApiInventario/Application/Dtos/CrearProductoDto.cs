using System.ComponentModel.DataAnnotations;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Dtos;

public class CrearProductoDto : IRequest<CrearProductoResponse>
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public int Stock { get; set; }
}


public class CrearProductoDtoHandler : IRequestHandler<CrearProductoDto, CrearProductoResponse>
{
    private readonly IProductoService _serviceProducto;

    public CrearProductoDtoHandler(IProductoService service)
    {
        _serviceProducto = service;
    }

    public async Task<CrearProductoResponse> Handle(CrearProductoDto request, CancellationToken cancellationToken)
    {
        var producto = new Productos();

        producto.Nombre = request.Nombre;
        producto.Stock = request.Stock;
        producto.Precio = request.Precio;
        producto.FechaCreacion = DateTime.Now;

        await _serviceProducto.ValidarQueNoExistaProducto(producto);
        var productoResult = await _serviceProducto.Crear(producto);

        var result = new CrearProductoResponse
        {
            IdProducto = productoResult.Id,
            Nombre = productoResult.Nombre,
            Precio = productoResult.Precio,
            Stock = productoResult.Stock,
            FechaCreacion = productoResult.FechaCreacion
        };

        return await Task.FromResult(result);
    }
}