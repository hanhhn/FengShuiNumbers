using System.Collections.Generic;

namespace Coffee.Libs.DataAccess.Provider
{
	public interface ISqlProvider
	{
		int ExecuteCommand(string query, params string[] paramaters);
		IEnumerable<T> ExecuteQuery<T>(string query, params string[] paramaters) where T : class;
	}
}
