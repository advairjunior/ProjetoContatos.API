using Contato.API.Dominio.Models;
using Contato.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contato.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
	private readonly IUsuarioService _usuarioService;

	public UsuariosController(IUsuarioService usuarioService)
	{
		_usuarioService = usuarioService;
	}

	[HttpPost("cadastro")]
	[AllowAnonymous]
	public async Task<IActionResult> RegistreUsuario([FromBody] UsuarioModel usuarioModel)
	{
		await _usuarioService.RegistreUsuario(usuarioModel);
		return Ok(new {message = "O usuario foi registrado"});
	}

	[HttpPut("login")]
	[AllowAnonymous]
	public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
	{
		string? token = await _usuarioService.RealizeLogin(loginModel);
		return token is null ? Unauthorized(new {message = "Login não autenticado"}) : Ok(token);
	}
}