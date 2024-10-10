using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STMComunication.Services.Interfaces;
using STMComunication.Dtos.User;
using STMComunication.Dtos.Login;
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
                    Message = "Login ou senha inválido."
                };
            }
            var result = await userService.UserLoginAsync(loginDto);

            if (result == null)
            {
                return new ApiResultDataDto<LoginResponseDto>()
                {
                    Success = false,
                    Message = "Login ou senha incorreto."
                };
            }

            return new ApiResultDataDto<LoginResponseDto>()
            {
                Data = result,
                Success = true,
                Message = "Usuário validado com sucesso."
            };
        }

        public static async Task<ApiResultDataDto<string>> CreateUserAsync([FromBody] UserRequestDto userRequestDto, IUserService userService)
        {
            try
            {
                var result = await userService.CreateUserAsync(userRequestDto);

                if (result == null)
                {
                    return new ApiResultDataDto<string>()
                    {
                        Success = false,
                        Message = $"Houve um problema interno na api ao criar o usuário. O resultado retornou nulo no método {nameof(CreateUserAsync)}."
                    };
                }

                return new ApiResultDataDto<string>()
                {
                    Success = true,
                    Message = $"/User/{result}",
                    Data = result
                };
            }
            catch (Exception e )
            {

                return new ApiResultDataDto<string>()
                {
                    Success = false,
                    Message = $"Houve um problema interno na api ao criar o usuário. O resultado retornou uma excessão do método {nameof(CreateUserAsync)}. {e.Message}."
                };
            }
        }
    }
}
