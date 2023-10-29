using Contato.API.Dominio.Entidades;
using Contato.API.Helpers;
using Dapper;
using System.Data;

namespace Contato.API.Repositories.Implementacoes;

public class ContatoRepository : IContatoRespository
{
	private readonly IDataContext _dataContext;

	public ContatoRepository(IDataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task Atualize(ContatoEntitie contato)
	{
		string sql = @"UPDATE Contatos SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";
		await _dataContext.CrieConexao().ExecuteAsync(sql, contato);
	}

	public async Task Delete(int id)
	{
		string sql = "DELETE FROM Contatos WHERE Id = @id";
        await _dataContext.CrieConexao().ExecuteAsync(sql, new { id });
	}

	public async Task<ContatoEntitie> ObtenhaPorId(int id)
	{
		string sql = "SELECT Id, Nome, Email, Telefone FROM Contatos WHERE Id = @id";
		return (await _dataContext.CrieConexao().QuerySingleOrDefaultAsync<ContatoEntitie>(sql, new { id }))!;
	}

	public async Task<IEnumerable<ContatoEntitie>> ObtenhaTodos()
	{
		string sql = "SELECT Id, Nome, Email, Telefone FROM Contatos";
		return await _dataContext.CrieConexao().QueryAsync<ContatoEntitie>(sql);
	}

	public async Task RegistreContato(ContatoEntitie contato)
	{
		string sql = "INSERT INTO Contatos (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";
		await _dataContext.CrieConexao().ExecuteAsync(sql, contato);
	}
}
