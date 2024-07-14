using Ejercicio5Modulo3.Data;
using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5Modulo3.Infrastructure.Repositories;

public class UsuarioRepository
{
    private readonly ApplicationDbContext _context;
    
    
    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task Seed_Usuarios(
            List<Usuario> usuarios
        )
    {
        
        var areUsers = await _context.Usuario.AnyAsync();
        
        if (areUsers)
        {
            throw new InvalidOperationException("Ya existen usuarios en la base de datos.");
        }
        
        await _context.Usuario.AddRangeAsync(usuarios);
        await _context.SaveChangesAsync();
    }
    
    
    public async Task<List<Usuario>>  Get_Usuarios(
        int? age,
        Genres? genre
        )
    {
        var usuarios = await _context.Usuario
            .Where(x => age == null || x.Edad == age)
            .Where(x => genre == null || x.Genero == genre.GetDescription())
            .ToListAsync();

        return usuarios;
    }
    
}