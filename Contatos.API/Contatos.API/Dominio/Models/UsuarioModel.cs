using Contato.API.Dominio.Enums;

namespace Contato.API.Dominio.Models;

public class UsuarioModel
{
    public string? Login { get; set; }
    public string? Senha { get; set; }
    public EnumTipoUsuario EnumTipoUsuario { get; set; }
}
