using Contato.API.Dominio.Entidades;
using Contato.API.Helpers;
using Dapper;
using System.Data;

namespace Contato.API.Repositories.Implementacoes;

public class UsuarioRepository : IUsuarioRepository
{
	private readonly IDataContext _dataContext;

	public UsuarioRepository(IDataContext dataContext) 
	{
		_dataContext = dataContext; 
	}

	public async Task RegistreUsuario(Usuario usuario)
	{
		using IDbConnection conexao = _dataContext.CrieConexao();
		string sql = "INSERT INTO Usuarios (Login, Tipo, SenhaHash) VALUES (@Login, @EnumTipoUsuario, @SenhaHash)";
		await conexao.ExecuteAsync(sql, usuario);
	}

	public async Task<Usuario> ConsulteLogin(string login, string senhaHash)
	{
		using IDbConnection conexao = _dataContext.CrieConexao();

		string sql = "SELECT Login, Tipo AS EnumTipoUsuario FROM Usuarios WHERE Login = @login AND SenhaHash = @senhaHash";
		return (await conexao.QuerySingleOrDefaultAsync<Usuario>(sql, new { login, senhaHash }))!;
	}
}
