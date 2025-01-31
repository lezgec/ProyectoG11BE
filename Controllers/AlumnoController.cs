using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Repository;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        private readonly IRepositoryAlumno _repositoryAlumno;

        public AlumnoController (IRepositoryAlumno repositoryAlumno)
        {
            _repositoryAlumno=repositoryAlumno;
        }

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
                return BadRequest(ex.Message);
            }
        }
    }
}
