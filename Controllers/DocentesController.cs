using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IRepositoryGestor _repositoryGestor;

        public DocenteController(IRepositoryGestor repositoryGestor)
        {
            _repositoryGestor = repositoryGestor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var docentes = await _repositoryGestor.ConsultarTodos();
                return Ok(docentes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener los docentes.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var docente = await _repositoryGestor.ConsultarPorId(id);
            if (docente == null)
                return NotFound(new { message = $"No se encontró el docente con ID {id}." });

            return Ok(docente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Docente docente)
        {
            var nuevoDocente = await _repositoryGestor.Crear(docente);
            return CreatedAtAction(nameof(GetById), new { id = nuevoDocente.Id }, nuevoDocente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Docente docente)
        {
            if (id != docente.Id)
                return BadRequest(new { message = "El ID no coincide." });

            await _repositoryGestor.Actualizar(docente);
            return Ok(new { message = "Docente actualizado con éxito.", docente });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoryGestor.Eliminar(id);
            return Ok(new { message = $"Docente con ID {id} eliminado correctamente." });
        }
    }
}
