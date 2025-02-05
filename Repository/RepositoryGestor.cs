using Microsoft.EntityFrameworkCore;
using ProyectoBE.Controllers;
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

        public async Task<int> Crear(Gestor gestor)
        {
            _context.Gestores.Add(gestor);
            await _context.SaveChangesAsync();
            return gestor.Id;
        }

        public async Task<Gestor?> ConsultarPorId(int id)
        {
            return await _context.Gestores
                .Where(g => g.Id == id && !g.IsDeleted)
                .Select(g => new Gestor
                {
                    Id = g.Id,
                    Cedula = g.Cedula,
                    Nombre = g.Nombre,
                    Apellido = g.Apellido,
                    Correo = g.Correo,
                    Telefono = g.Telefono,
                    Rol = g.Rol,
                    PropuestasIds = _context.Propuestas
                        .Where(p => p.RevisorId == g.Id && !p.IsDeleted)
                        .Select(p => p.Id)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Gestor?> ConsultarPorCedula(string cedula)
        {
            return await _context.Gestores
                .Where(g => g.Cedula == cedula && !g.IsDeleted)
                .Select(g => new Gestor
                {
                    Id = g.Id,
                    Cedula = g.Cedula,
                    Nombre = g.Nombre,
                    Apellido = g.Apellido,
                    Correo = g.Correo,
                    Telefono = g.Telefono,
                    Rol = g.Rol,
                    PropuestasIds = _context.Propuestas
                        .Where(p => p.RevisorId == g.Id && !p.IsDeleted)
                        .Select(p => p.Id)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Gestor>> ConsultarTodos()
        {
            return await _context.Gestores
                .Where(g => !g.IsDeleted)
                .Select(g => new Gestor
                {
                    Id = g.Id,
                    Cedula = g.Cedula,
                    Nombre = g.Nombre,
                    Apellido = g.Apellido,
                    Correo = g.Correo,
                    Telefono = g.Telefono,
                    Rol = g.Rol,
                    PropuestasIds = _context.Propuestas
                        .Where(p => p.RevisorId == g.Id && !p.IsDeleted)
                        .Select(p => p.Id)
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<List<int>> ConsultarPropuestasPorGestor(int gestorId)
        {
            return await _context.Propuestas
                .Where(p => p.RevisorId == gestorId && !p.IsDeleted)
                .Select(p => p.Id)
                .ToListAsync();
        }

        public async Task Update(Gestor gestor)
        {
            var gestorActualizar = await _context.Gestores.FindAsync(gestor.Id);
            if (gestorActualizar != null)
            {
                gestorActualizar.Cedula = gestor.Cedula;
                gestorActualizar.Nombre = gestor.Nombre;
                gestorActualizar.Apellido = gestor.Apellido;
                gestorActualizar.Correo = gestor.Correo;
                gestorActualizar.Telefono = gestor.Telefono;
                gestorActualizar.Rol = gestor.Rol;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int id)
        {
            var gestorEliminar = await _context.Gestores.FindAsync(id);
            if (gestorEliminar == null) return 0;

            gestorEliminar.IsDeleted = true;
            gestorEliminar.DeletedAt = DateTime.Now;

            _context.Gestores.Update(gestorEliminar);
            return await _context.SaveChangesAsync();
        }
    }
}
