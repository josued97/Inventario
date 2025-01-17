using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Exceptions;

public class ErrorMessage
{
    /// <summary>
    /// Mensaje de error
    /// </summary>
    public string mensaje { get; set; }

    /// <summary>
    /// Código status http para clasificar el error
    /// </summary>
    [JsonIgnore]
    public int Status { get; set; }

    /// <summary>
    /// Constructor que inicializa el ErrorMessage
    /// </summary>
    public ErrorMessage()
    {
        mensaje = string.Empty;
    }

    /// <summary>
    /// Serializa este objeto a formato JSON
    /// </summary>
    public override string ToString() => JsonSerializer.Serialize(this);
}
