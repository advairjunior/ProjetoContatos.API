using Contato.API.Dominio.Entidades;

namespace Contato.API.Repositories
{
    public interface IContatoRespository
    {
        Task RegistreContato(ContatoEntitie contato);
        Task<IEnumerable<ContatoEntitie>> ObtenhaTodos();
        Task<ContatoEntitie> ObtenhaPorId(int id);
        Task Atualize(ContatoEntitie contato);
        Task Delete(int id);
    }
}
