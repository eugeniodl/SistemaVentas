using AutoMapper;
using SistemaVentasAPI.Dto;
using SistemaVentasAPI.Models;

namespace SistemaVentasAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDto>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDto>().ReverseMap();
        }
    }
}
