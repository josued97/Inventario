using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IContext
{
    /// <summary>
    /// Manejo de la entidad prestamo
    /// </summary>
    DbSet<Clientes> Clientes { get; set; }
    DbSet<Pedidos> Pedidos { get; set; }
    DbSet<Productos> Productos { get; set; }

    /// <summary>
    /// Commit para la transacción
    /// </summary>
    Task CommitAsync();
}
