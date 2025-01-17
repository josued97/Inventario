namespace Application.Responses;

public class CrearProductoResponse
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaCreacion { get; set; }
}
