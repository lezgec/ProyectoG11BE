using Microsoft.EntityFrameworkCore;
using ProyectoBE.Models;
using ProyectoBE.Models.YourNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBE.Repository
{
    public class RepositoryAlumno : IRepositoryAlumno
    {
        private readonly ApplicationDbContext _context;

        public RepositoryAlumno(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo alumno
        public async Task<int> Crear(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return alumno.Id;
        }

        // Consultar alumno por ID incluyendo su propuesta y revisor
        public async Task<Alumno?> ConsultarPorId(int id)
        {
            return await _context.Alumnos
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync();
        }

        // Consultar alumno por Cédula
        public async Task<Alumno?> ConsultarPorCedula(string cedula)
        {
            return await _context.Alumnos
                .Where(a => a.Cedula == cedula && !a.IsDeleted)
                .FirstOrDefaultAsync();
        }

        // Consultar todos los alumnos activos
        public async Task<List<Alumno>> ConsultarTodos()
        {
            return await _context.Alumnos
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        // Eliminar un alumno (eliminación lógica)
        public async Task<int> Eliminar(int id)
        {
            var alumnoEliminar = await _context.Alumnos.FindAsync(id);
            if (alumnoEliminar == null) return 0;

            alumnoEliminar.IsDeleted = true;
            alumnoEliminar.DeletedAt = DateTime.Now;

            _context.Alumnos.Update(alumnoEliminar);
            return await _context.SaveChangesAsync();
        }

        // Actualizar datos de un alumno
        public async Task Actualizar(Alumno alumno)
        {
            var alumnoActualizar = await _context.Alumnos.FindAsync(alumno.Id);
            if (alumnoActualizar == null) return;

            alumnoActualizar.Cedula = alumno.Cedula;
            alumnoActualizar.Nombre = alumno.Nombre;
            alumnoActualizar.Apellido = alumno.Apellido;
            alumnoActualizar.Correo = alumno.Correo;
            alumnoActualizar.Telefono = alumno.Telefono;


            _context.Alumnos.Update(alumnoActualizar);
            await _context.SaveChangesAsync();
        }
    }
}
