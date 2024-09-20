using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos.SocialBenefits;
using STMComunication.Services.Interfaces;

namespace STMApi.Endpoints.SocialBenefitsEndpoint
{
    public static class SocialBenefitsReadOnlyEndpoint
    {
        public static async Task<IResult> GetAllAsync(ISocialBenefitsService socialBenefitsService, IMapper mapper)
        {
            var result = await socialBenefitsService.GetAllAsync();
            ICollection<SocialBenefitsResponseDto> response = mapper.Map<List<SocialBenefitsResponseDto>>(result);

            return Results.Ok(response);
        }

        public static async Task<IResult> GetByIdAsync([FromRoute] long id, ISocialBenefitsService socialBenefitsService, IMapper mapper)
        {
            var result = await socialBenefitsService.GetByIdAsync(id);
            SocialBenefitsResponseDto socialBenefitsDto = mapper.Map<SocialBenefitsResponseDto>(result); 

            return Results.Ok(socialBenefitsDto);
        }
    }
}
