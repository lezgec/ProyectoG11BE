using Microsoft.EntityFrameworkCore;
using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class ReposirotyRevisionPropuesta : IReposirotyRevisionPropuesta
    {
        private readonly ApplicationDbContext _context;
        public ReposirotyRevisionPropuesta(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RevisionPropuesta> ConsultarPorId(int id)
        {
            return await _context.RevisionesPropuesta.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<RevisionPropuesta>> ConsultarTodos()
        {
            return await _context.RevisionesPropuesta.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<int> crear(RevisionPropuesta revisionPropuesta)
        {
            _context.RevisionesPropuesta.Add(revisionPropuesta);
            await _context.SaveChangesAsync();
            return revisionPropuesta.Id;
        }

        public async Task<int> Delete(int id)
        {
            var revisionPropuestaEliminar = await _context.RevisionesPropuesta.FindAsync(id);
            if (revisionPropuestaEliminar == null) return 0;

            revisionPropuestaEliminar.IsDeleted = true;
            revisionPropuestaEliminar.DeletedAt = DateTime.Now;

            _context.RevisionesPropuesta.Update(revisionPropuestaEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(RevisionPropuesta revisionPropuesta)
        {
            RevisionPropuesta revisionPropuestaActualizar = await _context.RevisionesPropuesta.FindAsync(revisionPropuesta.Id);
            revisionPropuestaActualizar.Comentarios = revisionPropuesta.Comentarios;
            revisionPropuestaActualizar.Estado = revisionPropuesta.Estado;
            revisionPropuestaActualizar.FechaRevision = revisionPropuesta.FechaRevision;
            await _context.SaveChangesAsync();
        }
    }
}
