using Contato.API.Dominio.Entidades;
using Contato.API.Dominio.Models;
using Contato.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contato.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatosController : ControllerBase
{
	private readonly IContatoService _contatoService;

	public ContatosController(IContatoService contatoService)
	{
		_contatoService = contatoService;
	}

	[HttpPost("cadastro")]
	[Authorize]
	public async Task<IActionResult> RegistreContato([FromBody] ContatoModel contatoModel)
	{
		await _contatoService.RegistreContato(contatoModel);
		return Ok(new { message = "Contato registrado com sucesso"});
	}


	[HttpGet("{id}/obtenhaPorId")]
	[Authorize]
	public async Task<IActionResult> ObtenhaPorId(int id)
	{
		ContatoEntitie contato = await _contatoService.ObtenhaPorId(id);
		return contato is not null ? Ok(contato) : NoContent();
	}

	[HttpGet("obtenhaTodos")]
	[Authorize]
	public async Task<IActionResult> ObtenhaTodos()
	{
		IEnumerable<ContatoEntitie> contatos = await _contatoService.ObtenhaTodos();
		return contatos.Any() ? Ok(contatos) : NoContent();
	}

	[HttpPut("{id}/atualize")]
	[Authorize]
	public async Task<IActionResult> Atualize(int id, ContatoModel contatoModel)
	{
		await _contatoService.Atualize(id, contatoModel);
		return Ok(new {message = "Contato atualizado com sucesso"});
	}

	[HttpDelete("{id}/delete")]
	[Authorize(Roles = "Administrador")]
	public async Task<IActionResult> Delete(int id)
	{
		await _contatoService.Delete(id);
		return Ok(new {message = "Contato deletado com sucesso" });
	}
}
