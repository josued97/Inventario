namespace Domain.Entities;

public class PedidoProductos
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; }
    public virtual ICollection<Productos> Productos { get; set; }
}
