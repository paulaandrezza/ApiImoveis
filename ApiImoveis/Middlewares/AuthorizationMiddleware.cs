namespace ApiImoveis.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("UsuarioLogado"))
            {
                httpContext.Response.StatusCode = 401;
                return;
            }

            if (httpContext.Request.Headers.TryGetValue("UsuarioLogado", out var value))
            {
                if (value != "Admin")
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
                await _next(httpContext);
            }
        }
    }
}
