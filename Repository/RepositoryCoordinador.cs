using Microsoft.EntityFrameworkCore;
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

        public async Task<Coordinador> ConsultarPorId(int id)
        {
            return await _context.Coordinadores.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Coordinador>> ConsultarTodos()
        {
            return await _context.Coordinadores
                                 .Where(a => !a.IsDeleted) // Solo los no eliminados
                                 .ToListAsync();
        }

        public async Task<int> crear(Coordinador coordinador)
            {
                _context.Coordinadores.Add(coordinador);
                await _context.SaveChangesAsync();
                return coordinador.Id;
            }

        public async Task<int> Delete(int id)
        {
            var coordinadorEliminar = await _context.Coordinadores.FindAsync(id);
            if (coordinadorEliminar == null) return 0;

            coordinadorEliminar.IsDeleted = true;
            coordinadorEliminar.DeletedAt = DateTime.Now;

            _context.Coordinadores.Update(coordinadorEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Coordinador coordinador)
        {
            Coordinador coordinadorActualizar = await _context.Coordinadores.FindAsync(coordinador.Id);
            coordinadorActualizar.Nombre = coordinador.Nombre;
            coordinadorActualizar.Apellido = coordinador.Apellido;
            coordinadorActualizar.Correo = coordinador.Correo;
            coordinadorActualizar.Telefono = coordinador.Telefono;

            await _context.SaveChangesAsync();
        }
    }
}
