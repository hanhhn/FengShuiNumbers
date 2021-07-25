using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Coffee.Libs.DataAccess.Mapping
{
	public abstract class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : class
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			PropertyInfo prop = typeof(TEntity).GetProperty("Id");
			if (prop != null)
			{
				builder.HasKey("Id");

				if (prop.PropertyType.ToString() == typeof(int).ToString())
				{
					builder.Property("Id")
						.HasColumnName("ID")
						.HasColumnType("INT")
						.ValueGeneratedOnAdd();
				}
			}
		}

		public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(this);
		}
	}
}