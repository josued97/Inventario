using Domain.Interfaces;
using MediatR;

namespace Application.Dtos;

public class ActualizarProductoDto : IRequest<string>
{
    public int IdProducto { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}

public class ActualizarProductoDtoHandler : IRequestHandler<ActualizarProductoDto, string>
{
    private readonly IProductoService _service;

    public ActualizarProductoDtoHandler(IProductoService service)
    {
        _service = service;
    }

    public async Task<string> Handle(ActualizarProductoDto request, CancellationToken cancellationToken)
    {
        var producto = await _service.BuscarPorId(request.IdProducto);

        await _service.ValidarQueExistaProducto(producto);

        producto.Precio = request.Precio != 0 ? request.Precio : producto.Precio;
        producto.Stock = request.Stock != 0 ? request.Stock : producto.Stock;

        var result = await _service.ActualizarProducto(producto);

        return await Task.FromResult("OK");
    }
}
