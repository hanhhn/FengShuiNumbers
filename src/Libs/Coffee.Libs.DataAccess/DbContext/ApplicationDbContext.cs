using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Coffee.Libs.Infrastructure;

namespace Coffee.Libs.DataAccess.DbContext
{
	public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext
	{
		public static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(DbLoggerFactory).EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			TablesBuilder.Build(builder);
		}
	}
}