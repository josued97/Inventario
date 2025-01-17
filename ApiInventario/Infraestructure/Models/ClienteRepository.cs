using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Models;

public class ClienteRepository : IClienteRepository
{
    private readonly IContext _context;

    public ClienteRepository(IContext context)
    {
        _context = context;
    }

    public async Task<Clientes> InsertarAsync(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.CommitAsync();

        return cliente;
    }

    public async Task<List<Clientes>> ListarTodosAsync()
    {
        var listarClientes = _context.Clientes.ToListAsync();

        return await listarClientes;
    }


    public async Task<List<Clientes>> ListarPorEmailAsync(string email)
    {
        var listarClientes = _context.Clientes
            .Where(cliente => cliente.Email == email)
            .ToListAsync();

        return await listarClientes;
    }

}
