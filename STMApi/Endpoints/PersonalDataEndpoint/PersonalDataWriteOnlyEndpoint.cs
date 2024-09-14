using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos.PersonalData;
using STMComunication.Services.Interfaces;
using STMDomain.Domain;
using System.Security.Claims;

namespace STMComunication.Endpoints.PersonalDataEndpoint
{
    public static class PersonalDataWriteOnlyEndpoint
    {
        public static async Task<IResult> PostAsync([FromBody] PersonalDataPostDto personal, HttpContext context, IPersonalDataService personalDataService, IMapper mapper)
        {
            var userId = context.User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value;
            var personalData = mapper.Map<PersonalData>(personal);
            personalData.SetCreatedBy(userId);

            var result = await personalDataService.CreateAsync(personalData);
            long createdId = result.Id;

            return Results.Created($"/PersonalDatas/{createdId}", createdId);
        }
        
        public static async Task<IResult> PutAsync([FromBody] PersonalDataPutDto personal, HttpContext context, IPersonalDataService personalDataService, IMapper mapper)
        {
            var userId = context.User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value;
            var personalData = mapper.Map<PersonalData>(personal);
            personalData.SetUpdateddByAndUpdatedOn(userId);

            var result = await personalDataService.UpdateAsync(personalData);
            long createdId = result.Id;

            return Results.Ok($"/PersonalDatas/{createdId}");
        }

        public static async Task<IResult> DeleteAsync([FromRoute] long id, IPersonalDataService personalDataService)
        {
            bool result = await personalDataService.DeleteAsync(id);
            return Results.Ok(result);
        }

        
    }
}
