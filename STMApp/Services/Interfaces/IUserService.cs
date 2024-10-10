using STMApp.Dtos;

namespace STMApp.Services.Interfaces
{
    public interface IUserService
    {
        Task LoginAsync(HttpContext context, LoginResponseDto loginResponseDto);
        Task LoginOutAsync(HttpContext context);
        Task<ApiResultDataDto<LoginResponseDto>> GetLoginFromClientAsync(LoginRequestDto login);
        Task<bool> CreateAsync(UserRequestDto userRequestDto, string token);
    }
}
