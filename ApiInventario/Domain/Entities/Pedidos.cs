using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }


        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
