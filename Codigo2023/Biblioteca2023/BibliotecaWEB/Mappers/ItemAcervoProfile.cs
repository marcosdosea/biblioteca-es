using AutoMapper;
using BibliotecaWEB.Models;
using Core;
using Models;

namespace BibliotecaWEB.Mappers
{
	public class ItemAcervoProfile : Profile
	{
		public ItemAcervoProfile()
		{
			CreateMap<ItemAcervoViewModel, Itemacervo>().ReverseMap();

		}
	
	}
}
