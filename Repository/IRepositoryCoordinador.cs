using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryCoordinador
    {
        Task<int> crear(Coordinador coordinador);
    }
}
