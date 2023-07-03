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
        
        CreateMap<DistrictDto, District>()
            .ForMember(dest => dest.DistrictId, opt => opt.Ignore())
            .ForMember(dest => dest.DistrictUsers, opt => opt.MapFrom(src => src.DistrictUsers));

        CreateMap<District, DistrictDto>()
            .ForMember(dest => dest.DistrictUsers, opt => opt.MapFrom(src => src.DistrictUsers));
            
       
        CreateMap<User, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.UserSection, opt => opt.MapFrom(src => src.UserSection));

        CreateMap<Section, SectionDto>()
            .ForMember(dest => dest.SectionDistricts, opt => opt.MapFrom(src => src.SectionDistrict));
        
    }
}