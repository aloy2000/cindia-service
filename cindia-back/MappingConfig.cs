using AutoMapper;
using cindia_back.Models;
using cindia_back.Models.Dto;

namespace cindia_back;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(configure =>
        {
            configure.CreateMap<CasierDto, Casier>().ReverseMap();
            configure.CreateMap<Casier, CasierDto>();

            //configure.CreateMap<ProductDto, Product>().ReverseMap(); equivalent to 2 lines above
        });

        return mappingConfig;
    }
}