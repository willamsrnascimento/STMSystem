using STMApi.Endpoints.UserEndpoint;
using STMApi.Endpoints.UserEndpoit;

namespace STMApi.Endpoints
{
    public static class EndpointsConfigure
    {
        private static string TemplatePersonalData = "/PersonalDatas";
        private static string TemplateLogin = "/Login";
        private static string TemplateUser = "/User";
        public static void EndpointConfigure(this WebApplication app)
        {
            app.MapGet(TemplatePersonalData, PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetAllAsync);
            app.MapGet(TemplatePersonalData + "{id:long}", PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetByIdAsync);
            app.MapGet(TemplateLogin, LoginReadOnlyEndpoint.Login);
            app.MapPost(TemplateUser, UserWriteOnlyEndpoint.CreateUserAsync);

        }
    }
}
