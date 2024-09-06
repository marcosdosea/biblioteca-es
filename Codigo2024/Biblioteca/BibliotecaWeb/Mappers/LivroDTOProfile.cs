using AutoMapper;
using BibliotecaWEB.Models;
using Core.DTO;

namespace BibliotecaWEB.Mappers
{
    public class LivroDTOProfile : Profile
	{
		public LivroDTOProfile()
		{
			CreateMap<LivroViewModel, LivroDto>().ReverseMap();

		}
	}
}
