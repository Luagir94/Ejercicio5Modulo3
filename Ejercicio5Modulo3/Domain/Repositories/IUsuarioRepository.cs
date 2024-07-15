using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;

namespace Ejercicio5Modulo3.Domain.Repositories;

public interface IUsuarioRepository
{
    
    Task Seed_Usuarios(
            List<Usuario> usuarios
        );
    
    
    Task<List<Usuario>>  Get_Usuarios(
        int? age,
        Genres? genre
        );
}