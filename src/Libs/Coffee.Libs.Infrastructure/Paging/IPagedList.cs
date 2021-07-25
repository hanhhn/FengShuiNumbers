using System.Collections.Generic;

namespace Coffee.Libs.Infrastructure
{
	public interface IPagedList<T> where T : class
	{
		int PageIndex { get; }
		int PageSize { get; }
		int TotalRecord { get; }
		int TotalPage { get; }
		List<T> DataSource { get; }
	}
}