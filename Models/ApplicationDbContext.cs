using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProyectoBE.Models
{
    using Microsoft.EntityFrameworkCore;

    namespace YourNamespace.Models
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options) { }

            // DbSets para las tablas
            public DbSet<Alumno> Alumnos { get; set; } = null!;
            public DbSet<Gestor> Gestores { get; set; } = null!;
            public DbSet<Coordinador> Coordinadores { get; set; } = null!;
            public DbSet<Propuesta> Propuestas { get; set; } = null!;
            public DbSet<Secretaria> Secretaria { get; set; } = null!;
            public DbSet<RevisionPropuesta> RevisionesPropuesta { get; set; } = null!;
            public DbSet<PropuestaGestor> PropuestasGestores { get; set; } = null!;

            
        }
    }

}
