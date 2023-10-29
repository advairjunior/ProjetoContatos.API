using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Contato.API.Services.Implementacoes;

public class AuthService : IAuthService
{
	private readonly IConfiguration _configuration;
	public AuthService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string ComputeSha256Hash(string senha)
	{
		using SHA256 sha256Hash = SHA256.Create();
		byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

		StringBuilder builder = new();

		for (int i = 0; i < bytes.Length; i++)
		{
			builder.Append(bytes[i].ToString("x2"));
		}

		return builder.ToString();
	}

	public string GenerateJwtToken(string login, string tipo)
	{
		string issuer = _configuration["Jwt:Issuer"];
		string audience = _configuration["Jwt:Audience"];

		SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
		SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

		var claims = new List<Claim>
			{
				new Claim("login", login),
				new Claim(ClaimTypes.Role, tipo)
			};

		JwtSecurityToken token = new(
			issuer: issuer,
			audience: audience,
			expires: DateTime.Now.AddMinutes(120),
			signingCredentials: credentials,
			claims: claims);

		JwtSecurityTokenHandler tokenHandler = new();

		string stringToken = tokenHandler.WriteToken(token);

		return stringToken;
	}
}
