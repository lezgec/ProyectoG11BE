using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisorDePropuestasController : ControllerBase
    {
        private readonly IRepositoryPropuesta _repositoryRevisor;

        public RevisorDePropuestasController(IRepositoryPropuesta repositoryRevisor)
        {
            _repositoryRevisor = repositoryRevisor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var revisores = await _repositoryRevisor.ConsultarTodas();
                return Ok(revisores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener los revisores.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var revisor = await _repositoryRevisor.ConsultarPorId(id);
            if (revisor == null)
                return NotFound(new { message = $"No se encontró el revisor con ID {id}." });

            return Ok(revisor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RevisorDePropuestasController revisor)
        {
            await _repositoryRevisor.Crear(revisor);
            return Ok(new { message = "Revisor creado correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositoryRevisor.Delete(id);
            return Ok(new { message = $"Revisor con ID {id} eliminado correctamente." });
        }
    }
}
