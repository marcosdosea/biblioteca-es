using AutoMapper;
using Core;
using Models;

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
