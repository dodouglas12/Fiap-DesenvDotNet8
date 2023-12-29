using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Fiap_Aula6_AutenticacaoAutorizacao.Models;

namespace Fiap_Aula6_AutenticacaoAutorizacao.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ListaMemoriaMiddleware
    {
        private readonly RequestDelegate _next;

        public ListaMemoriaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            ListaUsuario.Usuarios = new List<Usuario>();
            ListaUsuario.Usuarios.Add(new Usuario { Id = 1, Username = "TesteFiap", Password = "TesteFiap" });
            ListaUsuario.Usuarios.Add(new Usuario { Id = 2, Username = "UsuarioTeste", Password = "Senha@123&Teste@!" });

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ListaMemoriaMiddlewareExtensions
    {
        public static IApplicationBuilder UseListaMemoriaMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ListaMemoriaMiddleware>();
        }
    }
}
