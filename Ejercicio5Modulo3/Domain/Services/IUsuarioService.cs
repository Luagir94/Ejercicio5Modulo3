using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ejercicio5Modulo3.Domain.Contracts;

public interface IUsuarioService
{
    public  Task Seed_Usuarios();
    
    public Task<List<Usuario>> Get_Usuarios(
        int? age,
        Genres? genre
    );
}

