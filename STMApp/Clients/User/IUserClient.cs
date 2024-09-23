using STMApp.Dtos.Login;
using STMApp.Models;

namespace STMApp.Clients.User
{
    public interface IUserClient
    {
        Task<LoginResponseDto> GetLogin(LoginRequestDto login);
    }
}
