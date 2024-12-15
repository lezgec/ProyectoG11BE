using Microsoft.EntityFrameworkCore;
using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;

namespace ProyectoBE.Repository
{
    public class RepositorySecreataria : IRepositorySecretaria
    {
        private readonly ApplicationDbContext _context;

        public RepositorySecreataria(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Secretaria> ConsultarPorId(int id)
        {
            return await _context.Secretaria.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Secretaria>> ConsultarTodos()
        {
            return await _context.Secretaria.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<int> crear(Secretaria secretaria)
        {
            _context.Secretaria.Add(secretaria);
            await _context.SaveChangesAsync();
            return secretaria.Id;
        }

        public async Task<int> Delete(int id)
        {
            var secretariaEliminar = await _context.Secretaria.FindAsync(id);
            if (secretariaEliminar == null) return 0;

            secretariaEliminar.IsDeleted = true;
            secretariaEliminar.DeletedAt = DateTime.Now;

            _context.Secretaria.Update(secretariaEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Secretaria secretaria)
        {
            Secretaria secretariaActualizar = await _context.Secretaria.FindAsync(secretaria.Id);
            secretariaActualizar.NombreArchivo = secretaria.NombreArchivo;
            secretariaActualizar.FechaCarga = secretaria.FechaCarga;;
            await _context.SaveChangesAsync();
        }
    }


}
