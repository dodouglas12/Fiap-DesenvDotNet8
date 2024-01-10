using Fiap_Aula3_Middleware.Models;

namespace Fiap_Aula3_Middleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NovoMiddleware
    {
        private readonly RequestDelegate _next;

        public NovoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            BDConnection.BancoDados = "Mudamos a conexão no Middleware"; 

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NovoMiddlewareExtensions
    {
        public static IApplicationBuilder UseNovoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NovoMiddleware>();
        }
    }
}
