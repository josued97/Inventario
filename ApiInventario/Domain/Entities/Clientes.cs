using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Clientes
{
    [Key]
    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }

    public Clientes()
    {
        Id = 0;
    }
}
