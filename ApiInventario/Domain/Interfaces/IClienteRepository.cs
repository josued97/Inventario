using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Clientes> InsertarAsync(Clientes cliente);
        Task<List<Clientes>> ListarTodosAsync();
        Task<List<Clientes>> ListarPorEmailAsync(string email);
    }
}
