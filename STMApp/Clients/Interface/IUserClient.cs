using STMApp.Dtos;
using STMApp.Dtos.Login;

namespace STMApp.Clients.Interface
{
    public interface IUserClient
    {
        Task<ApiResultDataDto<LoginResponseDto>> GetLoginAsync(LoginRequestDto login);
    }
}
