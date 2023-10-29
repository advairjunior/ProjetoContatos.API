using Contato.API.Dominio.Entidades;

namespace Contato.API.Repositories;

public interface IUsuarioRepository
{
    Task RegistreUsuario(Usuario usuario);
    Task<Usuario> ConsulteLogin(string login, string senhaHash);
}
