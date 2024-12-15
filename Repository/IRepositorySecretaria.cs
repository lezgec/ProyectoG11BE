using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositorySecretaria
    {
        
            Task<int> crear(Secretaria secretaria);

            Task<Secretaria> ConsultarPorId(int id);

            Task<List<Secretaria>> ConsultarTodos();

            Task Update(Secretaria secretaria);

            Task<int> Delete(int id);
        
    }
}