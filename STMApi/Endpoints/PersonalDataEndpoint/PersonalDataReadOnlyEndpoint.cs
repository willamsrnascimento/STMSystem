using Microsoft.AspNetCore.Mvc;
using STMComunication.Services.Interfaces;

namespace STMComunication.Endpoints.PersonalDataEndpoint
{
    public static class PersonalDataReadOnlyEndpoint
    {
        public static async Task<IResult> GetAllAsync(IPersonalDataService personalDataService)
        {
            return Results.Ok(await personalDataService.GetAllAsync());
        }

        public static async Task<IResult> GetByIdAsync([FromRoute] long id, IPersonalDataService personalDataService)
        {
            return Results.Ok(await personalDataService.GetByIdAsync(id));
        }

    }
}
