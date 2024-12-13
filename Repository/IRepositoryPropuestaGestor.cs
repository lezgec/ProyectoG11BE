using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryPropuestaGestor
    {
        Task<int> crear(PropuestaGestor propuestaGestor);
    }
}
