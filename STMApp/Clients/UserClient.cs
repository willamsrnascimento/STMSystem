using STMApp.Clients.Interface;
using STMApp.Dtos;
using STMApp.Dtos.Login;
using STMApp.Utils;
using System.Net;

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

        public async Task<ApiResultDataDto<LoginResponseDto>> GetLoginAsync(LoginRequestDto login)
        {
            var result = await _httpClient.PostAsJson("/User/Login", login);

            if (!result.IsSuccessStatusCode)
            {
                
                throw new Exception($"Something went wrong when calling the api {result.StatusCode}");
            }

            return await result.ReadContentAs<ApiResultDataDto<LoginResponseDto>>();
        }
    }
}
