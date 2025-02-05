using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;


namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorController : ControllerBase
    {
        private readonly IRepositoryGestor _repositoryGestor;

        public GestorController(IRepositoryGestor repositoryGestor)
        {
            _repositoryGestor = repositoryGestor;
        }

        // Obtener todos los gestores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaGestores = await _repositoryGestor.ConsultarTodos();
                return Ok(listaGestores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener los gestores.", error = ex.Message });
            }
        }

        //Obtener un gestor por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var gestor = await _repositoryGestor.ConsultarPorId(id);
                if (gestor == null)
                    return NotFound(new { message = $"No se encontró el gestor con ID {id}." });

                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener el gestor.", error = ex.Message });
            }
        }

        // Obtener un gestor por cédula
        [HttpGet("cedula/{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            try
            {
                var gestor = await _repositoryGestor.ConsultarPorCedula(cedula);
                if (gestor == null)
                    return NotFound(new { message = $"No se encontró el gestor con cédula {cedula}." });

                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener el gestor.", error = ex.Message });
            }
        }

        // Obtener propuestas asignadas a un gestor
        [HttpGet("{id}/propuestas")]
        public async Task<IActionResult> GetPropuestasPorGestor(int id)
        {
            try
            {
                var propuestasIds = await _repositoryGestor.ConsultarPropuestasPorGestor(id);
                return Ok(propuestasIds);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las propuestas del gestor.", error = ex.Message });
            }
        }

        //Crear un nuevo gestor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Gestor gestor)
        {
            try
            {
                if (gestor == null)
                    return BadRequest(new { message = "Los datos del gestor son inválidos." });

                var nuevoGestorId = await _repositoryGestor.Crear(gestor);
                return CreatedAtAction(nameof(GetById), new { id = nuevoGestorId }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear el gestor.", error = ex.Message });
            }
        }

        //Actualizar un gestor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Gestor gestor)
        {
            try
            {
                if (gestor == null || id != gestor.Id)
                    return BadRequest(new { message = "Los datos del gestor son inválidos." });

                var gestorExistente = await _repositoryGestor.ConsultarPorId(id);
                if (gestorExistente == null)
                    return NotFound(new { message = $"No se encontró el gestor con ID {id}." });

                gestorExistente.Cedula = gestor.Cedula;
                gestorExistente.Nombre = gestor.Nombre;
                gestorExistente.Apellido = gestor.Apellido;
                gestorExistente.Correo = gestor.Correo;
                gestorExistente.Telefono = gestor.Telefono;
                gestorExistente.Rol = gestor.Rol;
                gestorExistente.IsDeleted = gestor.IsDeleted;
                gestorExistente.DeletedAt = gestor.DeletedAt;

                // Solo actualizar propuestas si se envían
                if (gestor.PropuestasIds != null)
                {
                    gestorExistente.PropuestasIds = gestor.PropuestasIds;
                }

                await _repositoryGestor.Update(gestorExistente);
                return Ok(new { message = "Gestor actualizado con éxito.", gestor });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar el gestor.", error = ex.Message });
            }
        }


        //Eliminar un gestor (eliminación lógica)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var gestorExistente = await _repositoryGestor.ConsultarPorId(id);
                if (gestorExistente == null)
                    return NotFound(new { message = $"No se encontró el gestor con ID {id}." });

                await _repositoryGestor.Delete(id);
                return Ok(new { message = $"Gestor con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al eliminar el gestor.", error = ex.Message });
            }
        }
    }
}
