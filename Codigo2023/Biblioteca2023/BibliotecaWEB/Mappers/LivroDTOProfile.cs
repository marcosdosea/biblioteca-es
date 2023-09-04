using AutoMapper;
using Core;
using Core.DTO;
using Models;

namespace BibliotecaWEB.Mappers
{
	public class LivroDTOProfile : Profile
	{
		public LivroDTOProfile()
		{
			CreateMap<LivroModel, LivroDto>().ReverseMap();

		}
	}
}
