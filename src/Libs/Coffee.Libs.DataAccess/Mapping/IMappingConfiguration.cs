using Microsoft.EntityFrameworkCore;

namespace Coffee.Libs.DataAccess.Mapping
{
	public partial interface IMappingConfiguration
	{
		void ApplyConfiguration(ModelBuilder modelBuilder);
	}
}
