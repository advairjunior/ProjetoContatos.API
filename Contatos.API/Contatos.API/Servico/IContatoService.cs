using Contato.API.Dominio.Entidades;
using Contato.API.Dominio.Models;

namespace Contato.API.Services;

public interface IContatoService
{
    Task RegistreContato(ContatoModel contatoModel);
    Task<IEnumerable<ContatoEntitie>> ObtenhaTodos();
    Task<ContatoEntitie> ObtenhaPorId(int id);
    Task Atualize(int id, ContatoModel contatoModel);
    Task Delete(int id);
}
