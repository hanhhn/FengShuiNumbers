using FengShui.Service.Dtos;
using System.Collections.Generic;

namespace FengShui.Service
{
    public interface INumberService
	{
		List<PhoneDto> GetFengShui(FengShuiNumberConfiguration config);
	}
}
