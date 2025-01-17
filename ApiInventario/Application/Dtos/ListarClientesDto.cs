using Application.Responses;
using Domain.Interfaces;
using MediatR;

namespace Application.Dtos;

public class ListarClientesDto : IRequest<ListarClientesResponse>
{
}
public class ListarClientesDtoHandler : IRequestHandler<ListarClientesDto, ListarClientesResponse>
{

    private readonly IClienteService _service;
    public ListarClientesDtoHandler(IClienteService service)
    {
        _service = service;
    }

    public async Task<ListarClientesResponse> Handle(ListarClientesDto request,
                                            CancellationToken cancellationToken)
    {
        var resultListar = await _service.ListarClientes();


        var result = new ListarClientesResponse
        {
            Clientes = resultListar
        };

        return await Task.FromResult(result);
    }
}