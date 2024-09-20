using AutoMapper;
using Core.DTO;
using Models;

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
