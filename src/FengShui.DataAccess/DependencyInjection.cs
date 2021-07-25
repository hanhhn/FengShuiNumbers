using Microsoft.Extensions.DependencyInjection;
using Snp.TosFix.DataAccess.Repository;

namespace FengShui.DataAccess
{
    public static class DependencyInjection
    {
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IPhoneRepository, PhoneRepository>();
		}
	}
}
