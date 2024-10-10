using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos;
using STMComunication.Dtos.SocialBenefits;
using STMComunication.Services.Interfaces;

namespace STMApi.Endpoints.SocialBenefitsEndpoint
{
    public static class SocialBenefitsReadOnlyEndpoint
    {
        public static async Task<ApiResultDataDto<List<SocialBenefitsResponseDto>>> GetAllAsync(ISocialBenefitsService socialBenefitsService, IMapper mapper)
        {
            var result = await socialBenefitsService.GetAllAsync();
            List<SocialBenefitsResponseDto> response = mapper.Map<List<SocialBenefitsResponseDto>>(result);

            if (response == null)
            {
                return new ApiResultDataDto<List<SocialBenefitsResponseDto>>()
                {
                    Success = false,
                    Message = "Não houveram retorno de dados do repositório."
                };
            }

            return new ApiResultDataDto<List<SocialBenefitsResponseDto>>()
            {
                Success = true,
                Message = "Ok",
                Data = response
            };
        }

        public static async Task<ApiResultDataDto<SocialBenefitsResponseDto>> GetByIdAsync([FromRoute] long id, ISocialBenefitsService socialBenefitsService, IMapper mapper)
        {
            var result = await socialBenefitsService.GetByIdAsync(id);
            SocialBenefitsResponseDto socialBenefitsDto = mapper.Map<SocialBenefitsResponseDto>(result); 

            if (socialBenefitsDto == null)
            {
                return new ApiResultDataDto<SocialBenefitsResponseDto>()
                {
                    Success = false,
                    Message = "Não houveram retorno de dados do repositório."
                };
            }

            return new ApiResultDataDto<SocialBenefitsResponseDto>()
            {
                Success = true,
                Message = "Ok",
                Data = socialBenefitsDto
            };
        }
    }
}
