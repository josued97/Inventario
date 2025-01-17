using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Context;

public class Context : DbContext, IContext
{
    private readonly IConfiguration Config;

    public Context(DbContextOptions<Context> options, IConfiguration config) : base(options)
    {
        Config = config;
    }


    /// <inheritdoc/>>
    public async Task CommitAsync()
    {
        await SaveChangesAsync().ConfigureAwait(false);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mySchema");

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Productos> Productos { get; set; }
    public DbSet<Pedidos> Pedidos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
}
