using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Services.Interfaces;
using STMComunication.Dtos.User;
using STMComunication.Dtos.Login;
using STMApi.Security;
using System.Security.Cryptography;
using STMComunication.Dtos;

namespace STMComunication.Endpoints.UserEndpoint
{
    public static class UserWriteOnlyEndpoint
    {
        [AllowAnonymous]
        public static async Task<ApiResultDataDto<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto loginDto, IUserService userService)
        {
            if (!loginDto.IsValid())
            {
                return new ApiResultDataDto<LoginResponseDto>()
                {
                    Success = false,
                    Message = "Password or Username invalid."
                };
            }
            var result = await userService.UserLoginAsync(loginDto);

            if (result == null)
            {
                return new ApiResultDataDto<LoginResponseDto>()
                {
                    Success = false,
                    Message = "Password or Username incorrect."
                };
            }

            return new ApiResultDataDto<LoginResponseDto>()
            {
                Data = result,
                Success = true,
                Message = ""
            };
        }

        [AllowAnonymous]
        public static async Task<IResult> CreateUserAsync([FromBody] UserRequestDto userRequestDto, IUserService userService)
        {
            userRequestDto.Password = SecurityUtils.ComputeHash(userRequestDto.Password, SHA256.Create());
            var result = await userService.CreateUserAsync(userRequestDto);

            if (result == null)
            {
                return Results.Problem(title: "It wasnt possible to create a new user", statusCode: 500);
            }

            return Results.Created($"/User/{result}", result);
        }
    }
}
