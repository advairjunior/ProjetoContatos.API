using System.Data;

namespace Contato.API.Helpers;

public interface IDataContext
{
	IDbConnection CrieConexao();
	Task InicieBd();
}
