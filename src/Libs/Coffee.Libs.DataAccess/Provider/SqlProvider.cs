using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coffee.Libs.DataAccess.Provider
{
	public class SqlProvider : ISqlProvider, IDisposable
	{
		private readonly Microsoft.EntityFrameworkCore.DbContext _context;

		public SqlProvider(Microsoft.EntityFrameworkCore.DbContext DbContext)
		{
			_context = DbContext;
		}

		public int ExecuteCommand(string query, params string[] paramaters)
		{
			//if (paramaters == null || paramaters.Length == 0)
			//	return _context.Database.ExecuteSqlCommand(query);

			//return _context.Database.ExecuteSqlCommand(query, paramaters);
			throw new NotImplementedException();
		}

		public IEnumerable<T> ExecuteQuery<T>(string query, params string[] paramaters) where T : class
		{
			//DbSet<T> dbSet = _context.Set<T>();
			//if (dbSet == null)
			//{
			//	throw new NullReferenceException("Entity can not be set!");
			//}

			//if (paramaters == null || paramaters.Length == 0)
			//	return dbSet.FromSql(query).AsEnumerable();

			//return dbSet.FromSql(query, paramaters).AsEnumerable();
			throw new NotImplementedException();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
