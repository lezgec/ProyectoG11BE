using Microsoft.EntityFrameworkCore;
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
        public async Task<Alumno> ConsultarPorId(int id)
        {
            return await _context.Alumnos.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Alumno>> ConsultarTodos()
        {
            return await _context.Alumnos.Where(a => !a.IsDeleted).ToListAsync();
        }


        public async Task<int> Delete(int id)
        {
            var alumnoEliminar = await _context.Alumnos.FindAsync(id);
            if (alumnoEliminar == null) return 0;

            alumnoEliminar.IsDeleted = true;
            alumnoEliminar.DeletedAt = DateTime.Now;

            _context.Alumnos.Update(alumnoEliminar);
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Alumno alumno)
        {
            Alumno alumnoActualizar = await _context.Alumnos.FindAsync(alumno.Id);
            alumnoActualizar.Nombre = alumno.Nombre;
            alumnoActualizar.Apellido = alumno.Apellido;
            alumnoActualizar.Correo = alumno.Correo;
            alumnoActualizar.Telefono = alumno.Telefono;
            alumnoActualizar.PropuestaDefinicion = alumno.PropuestaDefinicion;
            await _context.SaveChangesAsync();
        }
    }
}
