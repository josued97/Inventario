using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductoRepository
{
    Task<Productos> ActualizarAsync(Productos Producto);
    Task<Productos> InsertarAsync(Productos Productos);
    Task<List<Productos>> ListarTodosAsync();
}
