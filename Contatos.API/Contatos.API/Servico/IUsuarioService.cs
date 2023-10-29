using Contato.API.Dominio.Models;

namespace Contato.API.Services;

public interface IUsuarioService
{
    Task RegistreUsuario(UsuarioModel usuarioModel);

    Task<string?> RealizeLogin(LoginModel loginModel);
}
