using STMApp.Dtos.Login;

namespace STMApp.Services.Interfaces
{
    public interface IUserService
    {
        Task LoginAsync(HttpContext context, LoginResponseDto loginResponseDto);
        Task LoginOutAsync(HttpContext context);
    }
}
