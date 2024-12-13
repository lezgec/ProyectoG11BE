using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class RepositoryAlumno : IRepositoryAlumno
    {
        private readonly ApplicationDbContext _context;

        public RepositoryAlumno(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> crear(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno.Id;
        }
    }
}
