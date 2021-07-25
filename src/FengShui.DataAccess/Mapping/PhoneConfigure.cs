using Coffee.Libs.DataAccess.Mapping;
using FengShui.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Snp.TosFix.DataAccess.Mapping
{
    public class PhoneConfigure : EntityTypeConfiguration<Phone>
	{
		public override void Configure(EntityTypeBuilder<Phone> builder)
		{
			base.Configure(builder);

			builder.ToTable(nameof(Phone));

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnType("INT")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Number)
				.HasColumnType("VARCHAR(10)");

			builder.Property(x => x.Network)
				.HasColumnType("VARCHAR(10)");
		}
	}
}
