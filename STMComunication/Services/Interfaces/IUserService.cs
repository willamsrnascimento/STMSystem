using STMComunication.Dtos.Login;
using STMComunication.Dtos.User;

namespace STMComunication.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(UserRequestDto user);
        Task<LoginResponseDto> UserLoginAsync(LoginRequestDto loginDto);
    }
}