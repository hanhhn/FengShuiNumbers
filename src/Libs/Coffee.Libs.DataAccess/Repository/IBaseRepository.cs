using Coffee.Libs.DataAccess.EntityRoot;

namespace Coffee.Libs.DataAccess.Repository
{
	public interface IBaseRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>, IQueryableRepository<TEntity>
		where TEntity : class, IEntityRoot
	{
	}
}
