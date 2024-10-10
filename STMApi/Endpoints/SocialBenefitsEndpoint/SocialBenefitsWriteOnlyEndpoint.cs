using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos;
using STMComunication.Dtos.SocialBenefits;
using STMComunication.Services.Interfaces;
using STMDomain.Domain;

namespace STMApi.Endpoints.SocialBenefitsEndpoint
{
    public static class SocialBenefitsWriteOnlyEndpoint
    {
        public static async Task<ApiResultDataDto<SocialBenefitsResponseDto>> Create([FromBody] SocialBenefitsRequestDto socialBenefitsRequestDto, ISocialBenefitsService socialBenefitsService, IMapper mapper)
        {
            SocialBenefits socialBenefits = mapper.Map<SocialBenefits>(socialBenefitsRequestDto);

            if(socialBenefits == null)
            {
                return new ApiResultDataDto<SocialBenefitsResponseDto>()
                {
                    Success = false,
                    Message = $"Houve um problema na chamada do método {nameof(Create)}. A entidade {nameof(SocialBenefitsRequestDto)} está nula."
                };
            }

            try
            {
                var result = await socialBenefitsService.CreateAsync(socialBenefits);
                SocialBenefitsResponseDto socialBenefitsResponseDto = mapper.Map<SocialBenefitsResponseDto>(result);

                return new ApiResultDataDto<SocialBenefitsResponseDto>()
                {
                    Success = true,
                    Message = $"/SocialBenefits/{result.Id}",
                    Data = socialBenefitsResponseDto
                };
            }
            catch (Exception e)
            {
                return new ApiResultDataDto<SocialBenefitsResponseDto>()
                {
                    Success = false,
                    Message = $"Houve um problema na chamada do serviço {nameof(ISocialBenefitsService)}. {e.Message}"
                };
            }
        }
        
    }
}
