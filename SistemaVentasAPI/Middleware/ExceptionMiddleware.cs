using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace SistemaVentasAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Continúa con el pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió una excepción no controlada");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = true,
                message = "Ocurrió un error en el servidor.",
                detail = ex.Message
            };

            switch (ex)
            {
                // Permisos denegados en SQL Server
                case SqlException sqlEx when sqlEx.Number == 229:
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    response = new
                    {
                        error = true,
                        message = "No tiene permisos para ejecutar esta operación en la base de datos.",
                        detail = sqlEx.Message
                    };
                    break;

                // Error de conexión SQL
                case SqlException sqlEx when sqlEx.Number == -1:
                    context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    response = new
                    {
                        error = true,
                        message = "No se pudo conectar con la base de datos.",
                        detail = sqlEx.Message
                    };
                    break;

                // Errores de autenticación/autorización
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = new
                    {
                        error = true,
                        message = "No está autorizado para acceder a este recurso.",
                        detail = ex.Message
                    };
                    break;

                // Argumentos inválidos o validaciones
                case ArgumentException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new
                    {
                        error = true,
                        message = "Solicitud inválida.",
                        detail = ex.Message
                    };
                    break;

                // Error genérico
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new
                    {
                        error = true,
                        message = "Error interno del servidor.",
                        detail = ex.Message
                    };
                    break;
            }

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            await context.Response.WriteAsync(json);
        }
    }
}
