using Ejercicio5Modulo3.Domain.Contracts;
using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;
using Ejercicio5Modulo3.Infrastructure.Dtos;
using Ejercicio5Modulo3.Infrastructure.Repositories;

namespace Ejercicio5Modulo3.Infrastructure.Services;

public class UsuarioService : IUsuarioService
{
    public readonly IRandomUserService  _randomUserService; 
    
    public readonly UsuarioRepository _usuarioRepository;
    
    public UsuarioService( IRandomUserService randomUserService, UsuarioRepository usuarioRepository)
    {
        _randomUserService = randomUserService;
        _usuarioRepository = usuarioRepository;
        
    }
    
    public async Task Seed_Usuarios()
    {
        try
        {
            var response = await _randomUserService.Get_Usuarios();

            var usuarios = response.Results.Select(
                x => Result.mapFromDto(x)
            ).ToList();
            
            await _usuarioRepository.Seed_Usuarios(usuarios);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al obtener usuarios: {e}");
            throw; 
        }
    }

    public Task<List<Usuario>> Get_Usuarios(
        int? age,
        Genres? genre
        )
    {
        try
        {
            return _usuarioRepository.Get_Usuarios(age, genre);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al obtener usuarios: {e}");
            throw;
        }
    }
}


public class DebuggingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Llamada al servidor
        var response = await base.SendAsync(request, cancellationToken);

        // Aquí puedes depurar la respuesta, por ejemplo, imprimiendo el contenido de la respuesta
        if (response.Content != null)
        {
            var content = await response.Content.ReadAsStringAsync();

        }

        return response;
    }
}