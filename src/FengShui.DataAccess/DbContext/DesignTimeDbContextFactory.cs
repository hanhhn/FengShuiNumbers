using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FengShui.DataAccess.DbContext
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FengShuiDbContext>
	{
		/// <summary>
		/// cmd in \src\api\Cf.Laundry
		/// dotnet ef migrations add init -p G:\laundry\src\libs\Coffee.DataAccess\Coffee.DataAccess.csproj
		/// dotnet ef database update
		/// </summary>
		public FengShuiDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<FengShuiDbContext>();
			var connectionString = "server=127.0.0.1;port=5432;database=laundry;user id=postgres;password=@chocon";
			builder.UseSqlServer(connectionString)
				   .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

			return new FengShuiDbContext(builder.Options);
		}
	}
}
