using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Coffee.Libs.DataAccess.Mapping
{
	public static class TablesConfiguration
	{
		public static void ConfigureEntity(this ModelBuilder modelBuilder, Assembly instance)
		{
			//dynamically load all entity and query type configurations
			var typeConfigurations = instance.GetTypes().Where(type =>
											(type.BaseType?.IsGenericType ?? false)
											&& (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))).ToList();


			var subTypeConfigurations = instance.GetTypes().Where(type =>
											type?.BaseType != null
											&& type?.BaseType?.BaseType != null
											&& (type.BaseType.BaseType?.IsGenericType ?? false)
											&& (type.BaseType.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))).ToList();

			foreach (var typeConfiguration in typeConfigurations.Union(subTypeConfigurations))
			{
				var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
				configuration.ApplyConfiguration(modelBuilder);
			}
		}
	}
}