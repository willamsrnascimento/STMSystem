using STMApp.Clients.Interface;
using STMApp.Dtos.Login;
using STMApp.Utils;

namespace STMApp.Clients
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7034");
        }

        public async Task<LoginResponseDto> GetLoginAsync(LoginRequestDto login)

        {
            var result = await _httpClient.PostAsJson("/User/Login", login);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling the api");
            }

            return await result.ReadContentAs<LoginResponseDto>();
        }
    }
}
