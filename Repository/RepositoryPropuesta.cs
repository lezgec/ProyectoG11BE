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
        public async Task<int> crear(Propuesta propuesta)
        {
            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();
            return propuesta.Id;
        }
    }
}
