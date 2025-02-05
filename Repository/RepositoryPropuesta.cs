using Microsoft.EntityFrameworkCore;
using ProyectoBE.Controllers;
using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;


namespace ProyectoBE.Repository
{
    public class RepositoryPropuesta : IRepositoryPropuesta
    {
        private readonly ApplicationDbContext _context;

        public RepositoryPropuesta(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Propuesta propuesta)
        {
            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();
            return propuesta.Id;
        }

        public async Task<List<Propuesta>> ConsultarTodas()
        {
            return await _context.Propuestas
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Propuesta?> ConsultarPorId(int id)
        {
            return await _context.Propuestas
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task Update(Propuesta propuesta)
        {
            var propuestaActualizar = await _context.Propuestas.FindAsync(propuesta.Id);
            if (propuestaActualizar != null)
            {
                propuestaActualizar.Titulo = propuesta.Titulo;
                propuestaActualizar.Definicion = propuesta.Definicion;
                propuestaActualizar.Estado = propuesta.Estado;
                propuestaActualizar.Observaciones = propuesta.Observaciones;
                propuestaActualizar.FechaModificacion = DateTime.Now;
                propuestaActualizar.Alumno1Id = propuesta.Alumno1Id;
                propuestaActualizar.Alumno2Id = propuesta.Alumno2Id;
                propuestaActualizar.RevisorId = propuesta.RevisorId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int id)
        {
            var propuestaEliminar = await _context.Propuestas.FindAsync(id);
            if (propuestaEliminar == null) return 0;

            propuestaEliminar.IsDeleted = true;
            propuestaEliminar.DeletedAt = DateTime.Now;

            _context.Propuestas.Update(propuestaEliminar);
            return await _context.SaveChangesAsync();
        }

        public Task Crear(RevisorDePropuestasController revisor)
        {
            throw new NotImplementedException();
        }
    }
}
