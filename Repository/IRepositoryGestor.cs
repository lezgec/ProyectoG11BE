using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryGestor
    {
        Task<int> crear(Gestor gestor);
    }
}
