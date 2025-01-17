using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteService
    {
        Task<Clientes> CrearCliente(Clientes clientes);
        Task<List<Clientes>> ListarClientes();
        Task ValidarQueNoExistaCliente(Clientes cliente);
    }
}
