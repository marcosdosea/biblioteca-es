using AutoMapper;
using Core;
using Models;

namespace Mappers
{
	public class LivroProfile : Profile
	{
		public LivroProfile()
		{
			CreateMap<LivroModel, Livro>().ReverseMap();

		}
	}
}
