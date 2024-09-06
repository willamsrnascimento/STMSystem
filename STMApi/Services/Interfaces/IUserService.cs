using STMComunication.Dtos;

namespace STMApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(UserRequestDto user);
        Task<string> UserLoginAsync(LoginRequestDto loginDto);
    }
}