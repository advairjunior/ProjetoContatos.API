namespace Contato.API.Services;

public interface IAuthService
{
    string GenerateJwtToken(string login, string tipo);
    string ComputeSha256Hash(string senha);
}
