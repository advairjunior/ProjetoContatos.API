using Contato.API.Helpers;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Contato.API.Data;

public class DataContext : IDataContext
{
	protected readonly IConfiguration Configuration;

	public DataContext(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IDbConnection CrieConexao() =>
		new SqliteConnection(Configuration.GetConnectionString("WebApiDatabase"));

	public async Task InicieBd()
	{
		using IDbConnection connection = CrieConexao();
		await crieTabelaUsuarios();
		await crieTabelaContatos();

		async Task crieTabelaUsuarios()
		{
			string sql = @"CREATE TABLE IF NOT EXISTS 
						   Usuarios (
								Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
								Login TEXT,
								Tipo INTEGER,
								SenhaHash TEXT
						   );";

			await connection.ExecuteAsync(sql);
		}

		async Task crieTabelaContatos()
		{
			string sql = @"CREATE TABLE IF NOT EXISTS 
						   Contatos (
								Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
								Nome TEXT,
								Email TEXT,
								Telefone TEXT
						   );";

			await connection.ExecuteAsync(sql);
		}
	}
}
