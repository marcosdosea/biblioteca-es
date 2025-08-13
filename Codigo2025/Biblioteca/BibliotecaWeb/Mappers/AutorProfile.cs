using AutoMapper;
using Core;
using Models;

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
