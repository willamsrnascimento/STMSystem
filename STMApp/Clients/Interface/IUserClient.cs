using STMApp.Dtos.Login;

namespace STMApp.Clients.Interface
{
    public interface IUserClient
    {
        Task<LoginResponseDto> GetLoginAsync(LoginRequestDto login);
    }
}
