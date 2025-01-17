using System.Web.Http;
using Application.Responses;
using Domain.Interfaces;
using MediatR;

namespace Application.Dtos;

public class ListarProductosDto : IRequest<ListarProductosResponse>
{
    public decimal PrecioMinimo { get; set; }
    public decimal PrecioMaximo { get; set; }
}

public class ListarProductosDtoHandler : IRequestHandler<ListarProductosDto, ListarProductosResponse>
{
    private readonly IProductoService _service;

    public ListarProductosDtoHandler(IProductoService service)
    {
        _service = service;
    }

    public async Task<ListarProductosResponse> Handle([FromBody] ListarProductosDto request,
                                            CancellationToken cancellationToken)
    {


        var resultListar = await _service.ListarPorRangoPrecio(request.PrecioMinimo, request.PrecioMaximo);

        var result = new ListarProductosResponse
        {
            Productos = resultListar
        };

        return await Task.FromResult(result);
    }
}
