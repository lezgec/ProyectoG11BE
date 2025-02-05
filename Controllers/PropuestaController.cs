using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Models;
using ProyectoBE.Repository;


namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropuestaController : ControllerBase
    {
        private readonly IRepositoryPropuesta _repositoryPropuesta;

        public PropuestaController(IRepositoryPropuesta repositoryPropuesta)
        {
            _repositoryPropuesta = repositoryPropuesta;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaPropuestas = await _repositoryPropuesta.ConsultarTodas();
                return Ok(listaPropuestas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las propuestas.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var propuesta = await _repositoryPropuesta.ConsultarPorId(id);
                if (propuesta == null)
                    return NotFound(new { message = $"No se encontró la propuesta con ID {id}." });

                return Ok(propuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener la propuesta.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Propuesta propuesta)
        {
            try
            {
                if (propuesta == null)
                    return BadRequest(new { message = "Los datos de la propuesta son inválidos." });

                var nuevaPropuesta = await _repositoryPropuesta.Crear(propuesta);
                return CreatedAtAction(nameof(GetById), new { id = nuevaPropuesta }, nuevaPropuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear la propuesta.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Propuesta propuesta)
        {
            try
            {
                if (propuesta == null || id != propuesta.Id)
                    return BadRequest(new { message = "Los datos de la propuesta son inválidos." });

                var propuestaExistente = await _repositoryPropuesta.ConsultarPorId(id);
                if (propuestaExistente == null)
                    return NotFound(new { message = $"No se encontró la propuesta con ID {id}." });

                await _repositoryPropuesta.Update(propuesta);
                return Ok(new { message = "Propuesta actualizada con éxito.", propuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al actualizar la propuesta.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var propuestaExistente = await _repositoryPropuesta.ConsultarPorId(id);
                if (propuestaExistente == null)
                    return NotFound(new { message = $"No se encontró la propuesta con ID {id}." });

                await _repositoryPropuesta.Delete(id);
                return Ok(new { message = $"Propuesta con ID {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al eliminar la propuesta.", error = ex.Message });
            }
        }
    }
}
