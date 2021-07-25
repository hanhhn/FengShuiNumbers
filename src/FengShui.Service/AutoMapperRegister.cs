using AutoMapper;
using Coffee.Libs.Infrastructure;
using FengShui.DataAccess.Entities;
using FengShui.Service.Dtos;

namespace FengShui.Service
{
    public static class AutoMapperRegister
	{
		public static void AddAutoMapper(this IMapperConfigurationExpression configAction)
		{
			configAction.AddProfile<MapperProfile>();
		}
	}

	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{
			CreateMap(typeof(PagedList<>), typeof(PagedList<>));
			CreateMap<Phone, PhoneDto>();
		}
	}
}