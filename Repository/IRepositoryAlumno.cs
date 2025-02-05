using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryAlumno
    {
        Task<int> Crear(Alumno alumno);
        Task<Alumno?> ConsultarPorId(int id);
        Task<Alumno?> ConsultarPorCedula(string cedula);
        Task<List<Alumno>> ConsultarTodos();
        Task Actualizar(Alumno alumno);
        Task<int> Eliminar(int id);
    }
}
