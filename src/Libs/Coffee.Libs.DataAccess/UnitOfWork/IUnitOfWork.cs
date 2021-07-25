using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Libs.DataAccess.UnitOfWork
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		int SaveChanges();
	}
}
