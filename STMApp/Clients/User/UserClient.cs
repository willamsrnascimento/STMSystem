using STMApp.Models;
using STMApp.Utils;

namespace STMApp.Clients.User
{
    public class UserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7034");
        }

        public async Task<LoginModel> GetLogin(LoginModel loginModel)

        {
            var result = await _httpClient.PutAsJsonAsync("/User/Login", loginModel);

            if (result.IsSuccessStatusCode)
            {
                return await result.ReadContentAs<LoginModel>();
            }

            return null;
        }
    }
}
