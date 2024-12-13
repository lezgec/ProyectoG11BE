using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class RepositoryPropuestaGestor
    {
        private readonly ApplicationDbContext _context;
        public RepositoryPropuestaGestor(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> crear(PropuestaGestor propuestaGestor)
        {
            _context.PropuestasGestores.Add(propuestaGestor);
            await _context.SaveChangesAsync();
            return propuestaGestor.Id;
        }
    }
}
