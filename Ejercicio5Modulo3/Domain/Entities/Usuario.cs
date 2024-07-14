using Ejercicio5Modulo3.Domain.Enums;
using Ejercicio5Modulo3.Infrastructure.Dtos;

namespace Ejercicio5Modulo3.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    
    public string Genero { get; set; }
    public string Email { get; set; }
    
    public string Nombre_Usuario { get; set; }
    public string Password { get; set; }
    public string Ciudad { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }


 
}