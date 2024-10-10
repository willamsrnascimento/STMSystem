using STMApp.Dtos;

namespace STMApp.Clients.Interface
{
    public interface IUserClient
    {
        Task<ApiResultDataDto<LoginResponseDto>> GetLoginAsync(LoginRequestDto login);
        Task<ApiResultDataDto<string>> CreateAsync(UserRequestDto userRequestDto, string token);
    }
}
