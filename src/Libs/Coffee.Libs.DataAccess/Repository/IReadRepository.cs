using Coffee.Libs.DataAccess.EntityRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Coffee.Libs.DataAccess.Repository
{
	public interface IReadRepository<TEntity> where TEntity : IEntityRoot
	{
		TEntity Get(params object[] keyValues);
		IEnumerable<TEntity> GetAll();
		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
	}
}
