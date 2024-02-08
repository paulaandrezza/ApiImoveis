
using ApiImoveis.Middlewares;

namespace ApiImoveis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ao inv�s de faz a inje��o de dependencia em Imovel Controller com:
            // private readonly ImovelService _imovelService = new ImovelService();
            // pode fazer aqui com:
            // builder.Services.AddSingleton<IImovelService, ImovelService>();
            // Usando o Singleton n�o � necess�rio o uso de static dentro de ImovelService

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            // 0 - Criar uma classe que seja um Middleware que fa�a o tratamento dos erros
            // app.UseMiddleware<NomeDaClasse>();

            // 1 - Se der pau (caiu no catch) retorne Status Code 500, com uma mensagem amig�vel

            // 2 - Criar um middleware que valide:
            // Se o header "UsuarioLogado" e est� preenchido
            // Al�m disso, se o header "UsuarioLogado" possui o valor "Admin"
            // Se isso n�o for verdade, retornar Status Code 401
            // Caso contr�rio, deixa seguir



            // MiddlewareFactory de Log de erros
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next.Invoke();
            //    }
            //    catch (Exception ex)
            //    {
            //        context.Response.StatusCode = 500;
            //        await context.Response.WriteAsync("Oops! Algo deu errado. Por favor, tente novamente mais tarde.");
            //    }
            //});
            app.MapControllers();

            app.Run();
        }
    }
}
