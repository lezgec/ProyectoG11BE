using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
        public class RepositoryCoordinador : IRepositoryCoordinador
        {
            private readonly ApplicationDbContext _context;
            public RepositoryCoordinador(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> crear(Coordinador coordinador)
            {
                _context.Coordinadores.Add(coordinador);
                await _context.SaveChangesAsync();
                return coordinador.Id;
            }
        }
}
