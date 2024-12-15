using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryAlumno
    {
        Task<int> crear(Alumno alumno);

        Task<Alumno> ConsultarPorId(int id);
        Task<List<Alumno>> ConsultarTodos();
        Task Update(Alumno alumno);
        Task<int> Delete(int id);
    }
}
