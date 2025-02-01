using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IRepositoryAlumno _repositoryAlumno;

        public AlumnoController(IRepositoryAlumno repositoryAlumno)
        {
            _repositoryAlumno = repositoryAlumno;
        }

        // Obtener todos los alumnos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListAlumnos = await _repositoryAlumno.ConsultarTodos();
                return Ok(ListAlumnos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener los alumnos.", error = ex.Message });
            }
        }

        // Obtener un alumno por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var alumno = await _repositoryAlumno.ConsultarPorId(id);
                if (alumno == null)
                    return NotFound(new { message = $"No se encontró el alumno con ID {id}." });

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener el alumno.", error = ex.Message });
            }
        }

        // Crear un nuevo alumno
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            try
            {
                if (alumno == null)
                    return BadRequest(new { message = "Los datos del alumno son inválidos." });

                var nuevoAlumno = await _repositoryAlumno.Crear(alumno);
                return CreatedAtAction(nameof(GetById), new { id = nuevoAlumno.Id }, nuevoAlumno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear el alumno.", error = ex.Message });
            }
        }

        // Actualizar un alumno
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            try
            {
                if (alumno == null || id != alumno.Id)
                    return BadRequest(new { message = "Los datos del alumno son inválidos." });

                var alumnoExistente = await _repositoryAlumno.ConsultarPorId(id);
                if (alumnoExistente == null)
                    return NotFound(new { message = $"No se encontró el alumno con ID {id}." });

                await _repositoryAlumno.Actualizar(alumno);
                return Ok(new { message = "Alumno actualizado con éxito.", alumno });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar el alumno.", error = ex.Message });
            }
        }

        // Eliminar un alumno
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alumnoExistente = await _repositoryAlumno.ConsultarPorId(id);
                if (alumnoExistente == null)
                    return NotFound(new { message = $"No se encontró el alumno con ID {id}." });

                await _repositoryAlumno.Eliminar(id);
                return Ok(new { message = $"Alumno con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al eliminar el alumno.", error = ex.Message });
            }
        }
    }
}
