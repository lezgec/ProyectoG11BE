using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryPropuesta
    {
        Task<int> crear(Propuesta propuesta);
    }
}
