﻿using Microsoft.Extensions.DependencyInjection;

namespace FengShui.Service
{
    public static class DependencyInjection
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<INumberService, NumberService>();
		}
	}
}