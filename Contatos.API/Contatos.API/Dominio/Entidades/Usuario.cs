using Contato.API.Dominio.Enums;

namespace Contato.API.Dominio.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? SenhaHash { get; set; }
    public EnumTipoUsuario EnumTipoUsuario { get; set; }
}
