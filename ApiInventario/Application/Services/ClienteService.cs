using Domain.Entities;
using Domain.Interfaces;
using static Domain.Exceptions.DomainError.Cliente;

namespace Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Clientes> CrearCliente(Clientes clientes)
        => await _repository.InsertarAsync(clientes);


    public async Task<List<Clientes>> ListarClientes()
        => await _repository.ListarTodosAsync();

    public async Task ValidarQueNoExistaCliente(Clientes cliente)
    {
        var clienteResponse = await _repository.ListarPorEmailAsync(cliente.Email);

        if (clienteResponse.Any())
            ClienteExisteException.Throw(cliente.Email);

    }
}
