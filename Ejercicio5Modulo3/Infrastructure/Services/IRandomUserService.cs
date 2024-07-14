using Ejercicio5Modulo3.Infrastructure.Dtos;
using Refit;

namespace Ejercicio5Modulo3.Infrastructure.Services;

public interface IRandomUserService
{
    [Get("/?results=500")]
    public Task<UsuarioApiList> Get_Usuarios();
}