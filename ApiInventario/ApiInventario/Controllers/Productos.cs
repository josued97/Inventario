using Application.Dtos;
using Azure.Core;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productos : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandler _errorHandler;
        public Productos(IMediator mediator, IErrorHandler errorHandler)
        {
            _mediator = mediator;
            _errorHandler = errorHandler;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearProducto(CrearProductoDto request)
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
        public async Task<IActionResult> ListarProductos(decimal precioMinimo, decimal precioMaximo)
        {
            try
            {
                var request = new ListarProductosDto
                {
                    PrecioMinimo = precioMinimo,
                    PrecioMaximo = precioMaximo
                };
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception error)
            {
                var errorMessage = _errorHandler.GetErrorObject(error);
                return StatusCode(errorMessage.Status, errorMessage);
            }
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarProducto(CrearProductoDto request)
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
    }
}
