using Microsoft.EntityFrameworkCore;
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

        public async Task<Gestor> ConsultarPorId(int id)
        {
            return await _context.Gestores.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Gestor>> ConsultarTodos()
        {
            return await _context.Gestores.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<int> crear(Gestor gestor)
        {
            _context.Gestores.Add(gestor);
            await _context.SaveChangesAsync();
            return gestor.Id;
        }

        public async  Task<int> Delete(int id)
        {
            var gestorEliminar = await _context.Alumnos.FindAsync(id);
            if (gestorEliminar == null) return 0;

            gestorEliminar.IsDeleted = true;
            gestorEliminar.DeletedAt = DateTime.Now;

            _context.Alumnos.Update(gestorEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Gestor gestor)
        {
            Gestor gestorActualizar = await _context.Gestores.FindAsync(gestor.Id);
            gestorActualizar.Nombre = gestor.Nombre;
            gestorActualizar.Apellido = gestor.Apellido;
            gestorActualizar.Correo = gestor.Correo;
            gestorActualizar.Telefono = gestor.Telefono;
            await _context.SaveChangesAsync();
        }
    }
}
