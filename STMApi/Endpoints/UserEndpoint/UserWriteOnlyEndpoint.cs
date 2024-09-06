using Microsoft.AspNetCore.Mvc;
using STMApi.Services.Interfaces;
using STMComunication.Dtos;

namespace STMApi.Endpoints.UserEndpoint
{
    public static class UserWriteOnlyEndpoint
    {
        //[AllowAnonymous]
        public static async Task<IResult> CreateUserAsync([FromBody] UserRequestDto userRequestDto, IUserService userService)
        {
            var result = await userService.CreateUserAsync(userRequestDto);

            if (result == null)
            {
                return Results.Problem(title: "It wasnt possible to create a new user", statusCode: 500);
            }

            return Results.Created($"/User/{result}", result);
        }
    }
}
