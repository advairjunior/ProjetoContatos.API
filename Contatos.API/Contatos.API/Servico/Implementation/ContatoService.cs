using AutoMapper;
using Contato.API.Dominio.Entidades;
using Contato.API.Dominio.Models;
using Contato.API.Repositories;

namespace Contato.API.Services.Implementacoes;

public class ContatoService : IContatoService
{
    private readonly IContatoRespository _contatoRepository;
    private readonly IMapper _mapper;

    public ContatoService(IContatoRespository contatoRespository, IMapper mapper)
    {
        _contatoRepository = contatoRespository;
        _mapper = mapper;
    }

    public async Task Atualize(int id, ContatoModel contatoModel)
    {
        ContatoEntitie contato =
            await _contatoRepository.ObtenhaPorId(id) ?? throw new KeyNotFoundException("Contato não encontrado");

        _mapper.Map(contatoModel, contato);

        await _contatoRepository.Atualize(contato);
    }

    public async Task<ContatoEntitie> ObtenhaPorId(int id) =>
        await _contatoRepository.ObtenhaPorId(id);

    public async Task<IEnumerable<ContatoEntitie>> ObtenhaTodos() =>
        await _contatoRepository.ObtenhaTodos();

    public async Task RegistreContato(ContatoModel contatoModel)
    {
        ContatoEntitie contato = _mapper.Map<ContatoEntitie>(contatoModel);
        await _contatoRepository.RegistreContato(contato);
    }

    public async Task Delete(int id)
    {
        if ((await _contatoRepository.ObtenhaPorId(id)) is null)
        {
            throw new KeyNotFoundException("Contato não encontrado");
        }

        await _contatoRepository.Delete(id);
    }
}
