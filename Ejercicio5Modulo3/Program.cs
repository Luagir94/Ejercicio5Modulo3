using Ejercicio5Modulo3.Api.Middlewares;
using Ejercicio5Modulo3.Data;
using Ejercicio5Modulo3.Domain.Contracts;
using Ejercicio5Modulo3.Domain.Enums;
using Ejercicio5Modulo3.Infrastructure.Repositories;
using Ejercicio5Modulo3.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace Ejercicio5Modulo3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
      
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });
            
            builder.Services.AddSwaggerGen(options =>
            {
                options.SchemaFilter<EnumAsStringSchemaFilter>();

            });
            
            builder.Services.AddRefitClient<IRandomUserService>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://randomuser.me/api");
                    
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
                    

                })
                .AddHttpMessageHandler<DebuggingHandler>(); // Añadir el DelegatingHandler aquí

// Asegúrate de registrar también tu DelegatingHandler
            builder.Services.AddTransient<DebuggingHandler>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            
            
            builder.Services.AddScoped<UsuarioRepository>();
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // app.UseMiddleware<ResponseHandlingMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}