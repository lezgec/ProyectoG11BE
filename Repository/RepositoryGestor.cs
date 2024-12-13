using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class RepositoryGestor : IRepositoryGestor
    {
        private readonly ApplicationDbContext _context;
        public RepositoryGestor(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> crear(Gestor gestor)
        {
            _context.Gestores.Add(gestor);
            await _context.SaveChangesAsync();
            return gestor.Id;
        }
    }
}
