using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IReposirotyRevisionPropuesta
    {
        Task<int> crear(RevisionPropuesta revisionPropuesta);
        Task<RevisionPropuesta> ConsultarPorId(int id);
        Task<List<RevisionPropuesta>> ConsultarTodos();
        Task Update(RevisionPropuesta revisionPropuesta);
        Task<int> Delete(int id);
    }
}
