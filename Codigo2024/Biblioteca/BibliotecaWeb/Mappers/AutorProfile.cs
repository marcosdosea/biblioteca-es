using AutoMapper;
using BibliotecaWEB.Models;
using Core;

namespace Mappers
{
    public class AutorProfile : Profile
	{
		public AutorProfile()
		{
			CreateMap<AutorViewModel, Autor>().ReverseMap();
		}
	}
}
