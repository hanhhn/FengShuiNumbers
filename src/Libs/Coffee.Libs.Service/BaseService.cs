using AutoMapper;
using Coffee.Libs.DataAccess.UnitOfWork;

namespace Coffee.Libs.Service
{
	public class BaseService : CommandService
	{
		public BaseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}
	}
}