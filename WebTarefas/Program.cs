using Microsoft.EntityFrameworkCore;
using WebTarefas.Infra.Context;
using WebTarefas.Infra.Repositories;
using WebTarefas.Services.TarefaServices;

namespace WebTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ListaTarefas"));

            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
            builder.Services.AddScoped<ITarefaService, TarefaService>();

            // Add services to the container.

            builder.Services.AddControllers();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

           // A parte de checagem de ambiente foi comentada para propósito de teste do container, para acessar o swagger
           // if (app.Environment.IsDevelopment())
           // {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Tarefas V1");
                });
           // }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
