using Microsoft.Extensions.DependencyInjection;

namespace Coffee.Libs.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCoreService(this IServiceCollection services)
		{
			//var engine = EngineContext.Current;
			//engine.ConfigureServices(services.BuildServiceProvider());
			//services.AddScoped<IIdentityContext, IdentityContext>();
			return services;
		}
	}
}
