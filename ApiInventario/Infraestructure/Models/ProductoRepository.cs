using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Models;

public class ProductoRepository : IProductoRepository
{
    private readonly IContext _context;

    public ProductoRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<Productos>> ListarTodosAsync()
    {
        var listarProductos = _context.Productos.ToListAsync();
        return await listarProductos;
    }

    public async Task<Productos> InsertarAsync(Productos Producto)
    {
        _context.Productos.Add(Producto);
        await _context.CommitAsync();

        return Producto;
    }

    public async Task<Productos> ActualizarAsync(Productos Producto)
    {
        var productoResult = _context.Productos
            .Where(pr => pr.Id == Producto.Id).Single();

        productoResult = Producto;
        await _context.CommitAsync();

        return productoResult;
    }

}
