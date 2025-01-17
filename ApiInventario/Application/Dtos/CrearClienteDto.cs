using System.ComponentModel.DataAnnotations;
using Application.Responses;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Dtos;

public class CrearClienteDto : IRequest<CrearClienteResponse>
{
    /// <summary>
    /// Email del usuario
    /// </summary>
    [Required]
    public string Email { get; set; }


    /// <summary>
    /// Nombre del usuario
    /// </summary>
    [Required]
    public string Nombre { get; set; }
}

public class CrearClienteDtoHandler : IRequestHandler<CrearClienteDto, CrearClienteResponse>
{

    private readonly IClienteService _service;
    public CrearClienteDtoHandler(IClienteService service)
    {
        _service = service;
    }

    public async Task<CrearClienteResponse> Handle(CrearClienteDto request,
                                      CancellationToken cancellationToken)
    {
        var cliente = new Clientes();

        cliente.Email = request.Email;
        cliente.Nombre = request.Nombre;
        cliente.FechaRegistro = DateTime.Now;

        await _service.ValidarQueNoExistaCliente(cliente);
        var clienteResult = await _service.CrearCliente(cliente);


        var result = new CrearClienteResponse
        {
            IdCliente = clienteResult.Id,
            Nombre = clienteResult.Nombre,
            FechaCreacion = clienteResult.FechaRegistro,
        };

        return await Task.FromResult(result);
    }
}