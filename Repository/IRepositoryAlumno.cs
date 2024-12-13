using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryAlumno
    {
        Task<int> crear(Alumno alumno);
    }
}
