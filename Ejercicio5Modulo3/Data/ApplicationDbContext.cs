using Ejercicio5Modulo3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5Modulo3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Usuario> Usuario { get; set; }


}