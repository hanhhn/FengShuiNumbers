using AutoMapper;
namespace Coffee.Libs.Service
{
	public class QueryService : IBaseService
	{
		protected readonly IMapper _mapper;

		public QueryService(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
