namespace STMApp.Clients
{
    public class PersonalDataClient
    {
        private readonly IHttpClientBuilder _httpClientBuilder;

        public PersonalDataClient(IHttpClientBuilder httpClientBuilder)
        {
            _httpClientBuilder = httpClientBuilder;
        }
    }
}
