using Ejercicio5Modulo3.Domain.Entities;

namespace Ejercicio5Modulo3.Aplication.Responses;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Genero { get; set; }
    public string Email { get; set; }
    public string NombreUsuario { get; set; }
    public string Ciudad { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    
    public static UsuarioResponse FromEntity(Usuario usuario)
    {
        return new UsuarioResponse
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Edad = usuario.Edad,
            Genero = usuario.Genero,
            Email = usuario.Email,
            NombreUsuario = usuario.Nombre_Usuario,
            Ciudad = usuario.Ciudad,
            Estado = usuario.Estado,
            Pais = usuario.Pais
        };
    }
}