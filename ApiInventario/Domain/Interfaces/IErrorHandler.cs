using Domain.Exceptions;

namespace Domain.Interfaces;
/// <summary>
/// ErrorHandler: Manejo global de errores
/// </summary>
public interface IErrorHandler
{
    /// <summary>
    /// Obtiene objeto ErrorMessage
    /// </summary>
    ErrorMessage GetErrorObject(Exception ex);

    /// <summary>
    /// Obtiene objecto Error y lo envia como HttpResponse
    /// </summary>
    HttpResponseMessage GetErrorResponse(Exception ex);

}
