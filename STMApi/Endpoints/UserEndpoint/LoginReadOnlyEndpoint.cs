using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STMApi.Services.Interfaces;
using STMComunication.Dtos;

namespace STMApi.Endpoints.UserEndpoit
{

    public static class LoginReadOnlyEndpoint
    {
        [AllowAnonymous]
        public static async Task<IResult> Login([FromBody] LoginRequestDto loginDto, IUserService userService)
        {
            if (!loginDto.IsValid())
            {
                return Results.BadRequest("Username and password is required.");
            }
            var result = await userService.UserLoginAsync(loginDto);

            if (result == null)
            {
                return Results.BadRequest("Password or username incorrect");
            }

            return Results.Ok(result);
        }
    }
}
