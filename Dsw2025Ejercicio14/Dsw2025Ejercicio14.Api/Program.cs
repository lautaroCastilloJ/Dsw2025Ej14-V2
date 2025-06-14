
using Dsw2025Ejercicio14.Api.Data;
using Dsw2025Ejercicio14.Api.Domain;

namespace Dsw2025Ejercicio14.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddHealthChecks();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 
            builder.Services.AddSingleton<IPersistencia, PersistenciaEnMemoria>();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHealthChecks("/health-check");
            

            app.Run();
        }
    }
}
