using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STMApi.Services.Implementations;
using STMComunication.Dtos;

namespace STMApi.Endpoints.UserEndpoit
{
    
    public static class LoginReadOnlyEndpoint
    {
        [AllowAnonymous]
        public static async Task<IResult> Login([FromBody] LoginRequestDto loginDto, UserService userService)
        {
            string token = await userService.UserLogin(loginDto);

            return Results.Ok(token);
        }
    }
}
