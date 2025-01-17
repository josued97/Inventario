using System.Net;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Utilities;

/// <summary>
/// ErrorHandler: Manejo global de errores
/// </summary>
public class ErrorHandler : IErrorHandler
{
    /// <inheritdoc/>
    public HttpResponseMessage GetErrorResponse(Exception ex)
    {
        var errorMessage = GetErrorObject(ex);
        return new HttpResponseMessage()
        {
            Content = new StringContent(errorMessage.mensaje.ToString(), System.Text.Encoding.UTF8, "application/json"),
            StatusCode = (HttpStatusCode)errorMessage.Status
        };
    }

    /// <inheritdoc/>
    public ErrorMessage GetErrorObject(Exception ex)
    {
        var errorMessage = new ErrorMessage();

        var exType = ex.GetType();

        if (exType == typeof(AggregateException) && ex.InnerException != null)
        {
            ex = ex.InnerException;
            exType = ex.GetType();
        }

        if (exType == typeof(DomainError.Cliente.ClienteExisteException))
        {
            errorMessage.mensaje = ex.Message;
            errorMessage.Status = (int)HttpStatusCode.BadRequest;
        }
        
        else
        {
            // Errores no controlados
            errorMessage.mensaje = "Error interno no controlado";
            errorMessage.Status = (int)HttpStatusCode.InternalServerError;
        }

        return errorMessage;
    }
}
