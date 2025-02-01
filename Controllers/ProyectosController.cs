using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

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
                var propuestas = await _repositoryPropuesta.ConsultarTodos();
                return Ok(propuestas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las propuestas.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var propuesta = await _repositoryPropuesta.ConsultarPorId(id);
            if (propuesta == null)
                return NotFound(new { message = $"No se encontró la propuesta con ID {id}." });

            return Ok(propuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Propuesta propuesta)
        {
            var nuevaPropuesta = await _repositoryPropuesta.Crear(propuesta);
            return CreatedAtAction(nameof(GetById), new { id = nuevaPropuesta.Id }, nuevaPropuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Propuesta propuesta)
        {
            if (id != propuesta.Id)
                return BadRequest(new { message = "El ID no coincide." });

            await _repositoryPropuesta.Actualizar(propuesta);
            return Ok(new { message = "Propuesta actualizada con éxito.", propuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoryPropuesta.Eliminar(id);
            return Ok(new { message = $"Propuesta con ID {id} eliminada correctamente." });
        }
    }
}
