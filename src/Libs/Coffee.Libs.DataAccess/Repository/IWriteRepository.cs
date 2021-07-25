using Coffee.Libs.DataAccess.EntityRoot;

namespace Coffee.Libs.DataAccess.Repository
{
	public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
	{
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Remove(TEntity entity);
		void Delete(TEntity entity);
		void UnDelete(TEntity entity);
	}
}