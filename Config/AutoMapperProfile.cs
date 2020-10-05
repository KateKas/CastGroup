using AutoMapper;
using CastGroup.Data.DTO;
using CastGroup.Entities;

namespace CastGroup.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Curso, CursoDTO>();
            CreateMap<CursoDTO, Curso>();
        }
    }
}