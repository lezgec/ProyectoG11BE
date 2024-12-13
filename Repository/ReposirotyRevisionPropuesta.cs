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
        public async Task<int> crear(RevisionPropuesta revisionPropuesta)
        {
            _context.RevisionesPropuesta.Add(revisionPropuesta);
            await _context.SaveChangesAsync();
            return revisionPropuesta.Id;
        }
    }
}
