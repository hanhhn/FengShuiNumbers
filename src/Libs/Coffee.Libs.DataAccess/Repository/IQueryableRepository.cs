using Coffee.Libs.DataAccess.EntityRoot;
using System.Linq;

namespace Coffee.Libs.DataAccess.Repository
{
	public interface IQueryableRepository<TEntity> where TEntity : IEntityRoot
	{
		IQueryable<TEntity> GetQuery();
	}
}