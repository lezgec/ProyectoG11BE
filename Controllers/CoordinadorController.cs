using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinadorDeRevisionController : ControllerBase
    {
        private readonly IRepositoryCoordinador _repositoryCoordinador;

        public CoordinadorDeRevisionController(IRepositoryCoordinador repositoryCoordinador)
        {
            _repositoryCoordinador = repositoryCoordinador;
        }

        // Obtener todos los coordinadores de revisión
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var coordinadores = await _repositoryCoordinador.ConsultarTodos();
                return Ok(coordinadores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener los coordinadores de revisión.", error = ex.Message });
            }
        }

        // Obtener un coordinador de revisión por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coordinador = await _repositoryCoordinador.ConsultarPorId(id);
            if (coordinador == null)
                return NotFound(new { message = $"No se encontró el coordinador con ID {id}." });

            return Ok(coordinador);
        }

        // Crear un nuevo coordinador de revisión
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CoordinadorDeRevision coordinador)
        {
            var nuevoCoordinador = await _repositoryCoordinador.Crear(coordinador);
            return CreatedAtAction(nameof(GetById), new { id = nuevoCoordinador.Id }, nuevoCoordinador);
        }

        // Actualizar un coordinador de revisión
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CoordinadorDeRevision coordinador)
        {
            if (id != coordinador.Id)
                return BadRequest(new { message = "El ID no coincide." });

            await _repositoryCoordinador.Actualizar(coordinador);
            return Ok(new { message = "Coordinador actualizado con éxito.", coordinador });
        }

        // Eliminar un coordinador de revisión
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoryCoordinador.Eliminar(id);
            return Ok(new { message = $"Coordinador con ID {id} eliminado correctamente." });
        }
    }
}
