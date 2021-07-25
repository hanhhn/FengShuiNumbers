using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.Libs.Infrastructure
{
	public interface IEngine
	{
		IServiceProvider GetServiceProvider();
		void ConfigureServices(IServiceProvider serviceProvider);
		T Resolve<T>() where T : class;
		object Resolve(Type type);
	}
}
