using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;
using ProyectoBE.Models;
using System;
using System.Threading.Tasks;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly IRepositorySecretaria _repositorySecretaria;

        public SecretariaController(IRepositorySecretaria repositorySecretaria)
        {
            _repositorySecretaria = repositorySecretaria;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var secretarias = await _repositorySecretaria.ConsultarTodos();
                return Ok(secretarias);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las secretarias.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var secretaria = await _repositorySecretaria.ConsultarPorId(id);
            if (secretaria == null)
                return NotFound(new { message = $"No se encontró la secretaria con ID {id}." });

            return Ok(secretaria);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Secretaria secretaria)
        {
            var nuevaSecretaria = await _repositorySecretaria.crear(secretaria);
            return CreatedAtAction(nameof(GetById), new { id = nuevaSecretaria }, nuevaSecretaria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Secretaria secretaria)
        {
            if (id != secretaria.Id)
                return BadRequest(new { message = "El ID no coincide." });

            await _repositorySecretaria.Update(secretaria);
            return Ok(new { message = "Secretaria actualizada con éxito.", secretaria });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repositorySecretaria.Delete(id);
            return Ok(new { message = $"Secretaria con ID {id} eliminada correctamente." });
        }
    }
}
