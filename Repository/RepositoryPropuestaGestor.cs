using Microsoft.EntityFrameworkCore;
using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class RepositoryPropuestaGestor : IRepositoryPropuestaGestor
    {
        private readonly ApplicationDbContext _context;
        public RepositoryPropuestaGestor(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PropuestaGestor> ConsultarPorId(int id)
        {
            return await _context.PropuestasGestores.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<PropuestaGestor>> ConsultarTodos()
        {
            return await _context.PropuestasGestores.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<int> crear(PropuestaGestor propuestaGestor)
        {
            _context.PropuestasGestores.Add(propuestaGestor);
            await _context.SaveChangesAsync();
            return propuestaGestor.Id;
        }

        public async Task<int> Delete(int id)
        {
            var propuestaGestorEliminar = await _context.PropuestasGestores.FindAsync(id);
            if (propuestaGestorEliminar == null) return 0;

            propuestaGestorEliminar.IsDeleted = true;
            propuestaGestorEliminar.DeletedAt = DateTime.Now;

            _context.PropuestasGestores.Update(propuestaGestorEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(PropuestaGestor propuestaGestor)
        {
            PropuestaGestor propuestaGestorActualizar = await _context.PropuestasGestores.FindAsync(propuestaGestor.Id);
            propuestaGestorActualizar.IdPropuesta = propuestaGestor.IdPropuesta;
            propuestaGestorActualizar.IdGestor = propuestaGestor.IdGestor;
            await _context.SaveChangesAsync();
        }
    }
}
