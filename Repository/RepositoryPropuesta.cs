using Microsoft.EntityFrameworkCore;
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

        public async Task<Propuesta> ConsultarPorId(int id)
        {
            return await _context.Propuestas.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Propuesta>> ConsultarTodos()
        {
            return await _context.Propuestas.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<int> crear(Propuesta propuesta)
        {
            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();
            return propuesta.Id;
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

        public async Task Update(Propuesta propuesta)
        {
            Propuesta propuestaActualizar = await _context.Propuestas.FindAsync(propuesta.Id);
            propuestaActualizar.Titulo = propuesta.Titulo;
            propuestaActualizar.Descripcion = propuesta.Descripcion;
            propuestaActualizar.Estado = propuesta.Estado;
            propuestaActualizar.FechaCreacion = propuesta.FechaCreacion;
            propuestaActualizar.IdAlumno = propuesta.IdAlumno;
            await _context.SaveChangesAsync();
        }
    }
}
