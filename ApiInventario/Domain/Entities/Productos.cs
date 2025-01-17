using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Productos
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaCreacion { get; set; }
}
