using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IReposirotyRevisionPropuesta
    {
        Task<int> crear(RevisionPropuesta revisionPropuesta);
    }
}
