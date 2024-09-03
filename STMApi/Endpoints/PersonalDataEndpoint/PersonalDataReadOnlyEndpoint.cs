using STMApi.Services.Implementations;
using STMApi.Services.Interfaces;

namespace STMApi.Endpoints.PersonalDataEndpoint
{
    public static class PersonalDataReadOnlyEndpoint
    {
        public static async Task<IResult> GetAllAsync(IPersonalDataService personalDataService)
        {
            return Results.Ok(await personalDataService.GetAllAsync());
        }

        public static async Task<IResult> GetByIdAsync(long id, IPersonalDataService personalDataService)
        {
            return Results.Ok(await personalDataService.GetByIdAsync(id));
        }

    }
}
