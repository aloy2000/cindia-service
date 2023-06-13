using AutoMapper;
using cindia_back.Models;
using cindia_back.Models.Dto;

namespace cindia_back;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CasierDto, Casier>()
            .ForMember(dest => dest.CasierId, opt => opt.Ignore())
            .ForMember(dest => dest.CasierUser, opt => opt.MapFrom(src => src.CasierUser));

        CreateMap<Casier, CasierDto>()
            .ForMember(dest => dest.CasierUser, opt => opt.MapFrom(src => src.CasierUser));
    }
}