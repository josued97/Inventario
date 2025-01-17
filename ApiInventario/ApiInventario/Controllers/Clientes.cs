using Application.Dtos;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiInventario.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Clientes : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IErrorHandler _errorHandler;
    public Clientes(IMediator mediator, IErrorHandler errorHandler)
    {
        _mediator = mediator;
        _errorHandler = errorHandler;
    }

    /// <summary>
    /// Crea cliente unico
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [HttpPost("Crear")]
    public async Task<IActionResult> CrearCliente(CrearClienteDto request)
    {
        try
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception error)
        {
            var errorMessage = _errorHandler.GetErrorObject(error);
            return StatusCode(errorMessage.Status, errorMessage);
        }
    }

    [HttpGet("ListarTodos")]
    public async Task<IActionResult> ListarClientes()
    {
        try
        {
            var request = new ListarClientesDto();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception error)
        {
            var errorMessage = _errorHandler.GetErrorObject(error);
            return StatusCode(errorMessage.Status, errorMessage);
        }
    }


}
