using Coffee.Libs.DataAccess.DbContext;
using FengShui.DataAccess.Entities;
using FengShui.DataAccess.Seed;
using Microsoft.EntityFrameworkCore;

namespace FengShui.DataAccess.DbContext
{
    public class FengShuiDbContext : ApplicationDbContext
    {
		public FengShuiDbContext(DbContextOptions<FengShuiDbContext> options) : base(options)
		{
		}

		public DbSet<Phone> Phones { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			TablesBuilder.Build(builder);
			DefaultSeeding.Seeding(builder);
		}
	}
}
