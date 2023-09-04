using AutoMapper;
using Models;
using Core;

namespace Mappers
{
	public class AutorProfile : Profile
	{
		public AutorProfile()
		{
			CreateMap<AutorModel, Autor>().ReverseMap();
		}
	}
}
