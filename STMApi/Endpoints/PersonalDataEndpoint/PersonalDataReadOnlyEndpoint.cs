using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos.PersonalData;
using STMComunication.Services.Interfaces;

namespace STMComunication.Endpoints.PersonalDataEndpoint
{
    public static class PersonalDataReadOnlyEndpoint
    {
        public static async Task<IResult> GetAllAsync(IPersonalDataService personalDataService, IMapper mapper)
        {
            var personalData = await personalDataService.GetAllAsync();
            ICollection<PersonalDataResponseDto> personalDataResponseDtos = mapper.Map<ICollection<PersonalDataResponseDto>>(personalData);

            return Results.Ok(personalDataResponseDtos);
        }

        public static async Task<IResult> GetByIdAsync([FromRoute] long id, IPersonalDataService personalDataService, IMapper mapper)
        {
            var personalData = await personalDataService.GetByIdAsync(id);
            PersonalDataResponseDto personalDataResponseDtos = mapper.Map<PersonalDataResponseDto>(personalData);

            return Results.Ok(personalDataResponseDtos);
        }

    }
}
