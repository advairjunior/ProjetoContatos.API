using AutoMapper;
using Contato.API.Dominio.Entidades;
using Contato.API.Dominio.Models;

namespace Contato.API.Helpers;

public class AutoMapper : Profile
{
	public AutoMapper()
	{
		CreateMap<UsuarioModel, Usuario>();
		CreateMap<ContatoModel, ContatoEntitie>();
	}
}
