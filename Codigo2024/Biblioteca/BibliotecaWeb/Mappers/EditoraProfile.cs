using AutoMapper;
using Core;
using BibliotecaWEB.Models;

namespace Mappers
{
	public class EditoraProfile : Profile
	{
		public EditoraProfile()
		{
			CreateMap<EditoraViewModel, Editora>().ReverseMap();
		}
	}
}
