using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Coffee.Libs.DataAccess.EntityRoot;
using Coffee.Libs.DataAccess.Mapping;
using System.Reflection;

namespace Coffee.Libs.DataAccess.SqlServer
{
	public class SqlServerEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
	{
		public override void Configure(EntityTypeBuilder<TEntity> builder)
		{
			base.Configure(builder);

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

			prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreatedDate));
			if (prop != null)
			{
				builder.Property(nameof(IChangeableEntity.CreatedDate))
					.HasColumnName("CREATED_DATE")
					.HasColumnType("DATETIME");
			}

			prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.CreatedBy));
			if (prop != null)
			{
				builder.Property(nameof(IChangeableEntity.CreatedBy))
					.HasColumnName("CREATED_BY")
					.HasColumnType("VARCHAR(50)");
			}

			prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifiedDate));
			if (prop != null)
			{
				builder.Property(nameof(IChangeableEntity.ModifiedDate))
					.HasColumnName("MODIFIED_DATE")
					.HasColumnType("DATETIME");
			}

			prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.ModifiedBy));
			if (prop != null)
			{
				builder.Property(nameof(IChangeableEntity.ModifiedBy))
					.HasColumnName("MODIFIED_BY")
					.HasColumnType("VARCHAR(50)");
			}

			prop = typeof(TEntity).GetProperty(nameof(IDeleteEntity.IsDeleted));
			if (prop != null)
			{
				builder.Property(nameof(IDeleteEntity.IsDeleted))
					.HasColumnName("IS_DELETED")
					.HasColumnType("BIT");
			}

			prop = typeof(TEntity).GetProperty(nameof(IChangeableEntity.UpdatedToken));
			if (prop != null)
			{
				builder.Property(nameof(IChangeableEntity.UpdatedToken))
					.HasColumnName("UPDATED_TOKEN")
					.HasColumnType("VARCHAR(36)")
					.IsConcurrencyToken();
			}

			prop = typeof(TEntity).GetProperty("Note");
			if (prop != null)
			{
				builder.Property("Note")
					.HasColumnName("NOTE")
					.HasColumnType("VARCHAR(250)");
			}
		}
	}
}