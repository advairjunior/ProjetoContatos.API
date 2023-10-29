using AutoMapper;
using Contato.API.Dominio.Entidades;
using Contato.API.Dominio.Models;
using Contato.API.Repositories;

namespace Contato.API.Services.Implementacoes;

public class UsuarioService : IUsuarioService
{
	private readonly IAuthService _authService;
	private readonly IUsuarioRepository _usuarioRepository;
	private readonly IMapper _mapper;

	public UsuarioService(IAuthService authService, IMapper mapper, IUsuarioRepository usuarioRepository) 
	{
		_authService = authService; 
		_mapper = mapper;
		_usuarioRepository = usuarioRepository;
	}

	public async Task RegistreUsuario(UsuarioModel usuarioModel)
	{
		Usuario usuario = _mapper.Map<Usuario>(usuarioModel);

		string senhaHash = _authService.ComputeSha256Hash(usuarioModel.Senha!);
		usuario.SenhaHash = senhaHash;

		await _usuarioRepository.RegistreUsuario(usuario);
	}

	public async Task<string?> RealizeLogin(LoginModel loginModel)
	{
		string senhaHash = _authService.ComputeSha256Hash(loginModel.Senha!);

		Usuario usuario = await _usuarioRepository.ConsulteLogin(loginModel.Login!, senhaHash);

		if (usuario is null)
		{
			return null;
		}

		string token = _authService.GenerateJwtToken(usuario.Login!, usuario.EnumTipoUsuario.ToString());
		return token;
	}
}
