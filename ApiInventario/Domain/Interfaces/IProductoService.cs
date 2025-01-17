using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductoService
{
    Task<Productos> ActualizarProducto(Productos productoActualizar);
    Task<Productos> BuscarPorId(int id);
    Task<Productos> Crear(Productos producto);
    Task<List<Productos>> ListarPorRangoPrecio(decimal precioMinimo, decimal precioMaximo);
    Task<List<Productos>> ListarTodos();
    Task ValidarQueExistaProducto(Productos producto);
    Task ValidarQueNoExistaProducto(Productos producto);
}
