using Domain.Entities;
using Domain.Interfaces;
using static Domain.Exceptions.DomainError;

namespace Application.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Productos> Crear(Productos producto)
       => await _repository.InsertarAsync(producto);

    public async Task<List<Productos>> ListarTodos()
        => await _repository.ListarTodosAsync();

    public async Task<List<Productos>> ListarPorRangoPrecio(decimal precioMinimo, decimal precioMaximo)
    {
        var listProductos = await _repository.ListarTodosAsync();
        if (listProductos.Any() && precioMaximo == 0)
            precioMaximo = listProductos.OrderByDescending(x => x.Precio).First().Precio;

        listProductos = listProductos.Where(x
            => x.Precio >= precioMinimo
            && x.Precio <= precioMaximo)
            .OrderBy(pr => pr.Stock).ToList();

        return listProductos;
    }
    
    public async Task<Productos> BuscarPorId(int id)
    {
        return await _repository.BuscarPorIdAsync(id);
    }

    public async Task ValidarQueNoExistaProducto(Productos producto)
    {
        var productoResponse = await _repository.ListarTodosAsync();

        productoResponse = productoResponse.Where(x => x.Id == producto.Id).ToList();

        if (productoResponse.Any())
            ProductoExisteException.Throw(producto.Nombre);
    }

    public async Task ValidarQueExistaProducto(Productos producto)
    {
        var productoResponse = await _repository.ListarTodosAsync();

        productoResponse = productoResponse.Where(x => x.Id == producto.Id).ToList();

        if (!productoResponse.Any())
            ProductoNoExisteException.Throw(producto.Nombre);
    }

    public async Task<Productos> ActualizarProducto(Productos productoActualizar)
    {
        var productoResult = await _repository.BuscarPorIdAsync(productoActualizar.Id);

        productoResult = productoActualizar;

        var result = await _repository.ActualizarAsync(productoResult);

        return result;
    }
}
