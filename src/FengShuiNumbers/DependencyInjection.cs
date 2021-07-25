using AutoMapper;
using Coffee.Libs.DataAccess.UnitOfWork;
using FengShui.DataAccess;
using FengShui.DataAccess.DbContext;
using FengShui.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FengShuiNumbers
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddCustomConfigures(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddCustomDbContext(configuration);

			services.AddCustomAutoMapper();

			services.AddCustomServices();

			return services;
		}

		public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var sqlConnectionString = configuration.GetValue<string>("DefaultConnectionString");

			services
				.AddDbContext<FengShuiDbContext>(options => options.UseSqlServer("Server=TCIS-SSC-50120D;Database=TOSToolFix;User Id=sqluser;Password=@chocon"))
				.AddScoped<IUnitOfWork, UnitOfWork<FengShuiDbContext>>();
		}

		public static void AddCustomAutoMapper(this IServiceCollection services)
		{
			Action<IMapperConfigurationExpression> InitMapper = config =>
			{
				config.AddAutoMapper();
			};

			var configuration = new MapperConfiguration(InitMapper);
			configuration.CompileMappings();
			IMapper mapper = configuration.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddRepositories();
			services.AddServices();
		}
	}
}
