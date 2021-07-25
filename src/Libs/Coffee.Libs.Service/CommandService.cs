using AutoMapper;
using Coffee.Libs.DataAccess.UnitOfWork;

namespace Coffee.Libs.Service
{
	public class CommandService : QueryService
	{
		protected readonly IUnitOfWork _unitOfWork;

		public CommandService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
		{
			_unitOfWork = unitOfWork;
		}
	}
}