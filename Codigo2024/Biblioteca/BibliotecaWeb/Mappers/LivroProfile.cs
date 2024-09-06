using AutoMapper;
using Core;
using BibliotecaWEB.Models;

namespace Mappers
{
	public class LivroProfile : Profile
	{
		public LivroProfile()
		{
			CreateMap<LivroViewModel, Livro>().ReverseMap();

		}
	}
}
