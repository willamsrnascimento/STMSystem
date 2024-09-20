using AutoMapper;
using STMComunication.Dtos;
using STMComunication.Dtos.PersonalData;
using STMComunication.Dtos.SocialBenefits;
using STMDomain.Domain;

namespace STMComunication.Mappings
{
    public class MappingConfigure
    {
        public static MapperConfiguration AddMapperConfigure()
        {
            var mappingConfigure = new MapperConfiguration(config =>
            {
                config.CreateMap<ContactResquestDto, Contact>();
            
                config.CreateMap<SocialBenefitsRequestDto, SocialBenefits>().ReverseMap();
                config.CreateMap<SocialBenefitsResponseDto, SocialBenefits>().ReverseMap();

                config.CreateMap<AddressRequestDto, Address>();

                config.CreateMap<FamilyDataRequestDto, FamilyData>();

                config.CreateMap<PersonalDataPostDto, PersonalData>().ReverseMap()
                .ForMember(dst => dst.Contacts, src => src.MapFrom(src => src.Contacts))
                .ForMember(dst => dst.SocialBenefits, src => src.MapFrom(src => src.SocialBenefits))
                .ForMember(dst => dst.Address, src => src.MapFrom(src => src.Address))
                .ForMember(dst => dst.FamilyData, src => src.MapFrom(src => src.FamilyData));
                config.CreateMap<PersonalDataPutDto, PersonalData>();
                config.CreateMap<PersonalDataResponseDto, PersonalData>().ReverseMap();
                
            });

            return mappingConfigure;
        }
    }
}
