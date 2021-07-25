using System.Collections.Generic;

namespace Coffee.Libs.Core
{
	public class SingletonList<T> : Singleton<List<T>>
	{
		static SingletonList()
		{
			Singleton<List<T>>.Instance = new List<T>();
		}

		public static new List<T> Instance => Singleton<List<T>>.Instance;
	}
}
