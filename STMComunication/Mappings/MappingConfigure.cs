using AutoMapper;
using STMComunication.Dtos;
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
                config.CreateMap<SocialBenefitsRequestDto, SocialBenefits>();
                config.CreateMap<AddressRequestDto, Address>();
                config.CreateMap<FamilyDataRequestDto, FamilyData>();


                config.CreateMap<PersonalDataRequestDto, PersonalData>()
                .ForMember(dst => dst.Contacts, src => src.MapFrom(src => src.Contacts))
                .ForMember(dst => dst.SocialBenefits, src => src.MapFrom(src => src.SocialBenefits))
                .ForMember(dst => dst.Address, src => src.MapFrom(src => src.Address))
                .ForMember(dst => dst.FamilyData, src => src.MapFrom(src => src.FamilyData));

                config.CreateMap<PersonalData, PersonalDataRequestDto>();
            });

            return mappingConfigure;
        }
    }
}
