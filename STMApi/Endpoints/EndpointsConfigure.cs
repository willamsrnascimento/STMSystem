using STMComunication.Endpoints.UserEndpoint;
using STMComunication.Endpoints.UserEndpoit;

namespace STMComunication.Endpoints
{
    public static class EndpointsConfigure
    {
        private const string TemplatePersonalData = "/PersonalDatas";
        private const string TemplateUser = "/User";
        public static void EndpointConfigure(this WebApplication app)
        {
            app.MapGet(TemplatePersonalData, PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetAllAsync);
            app.MapGet(TemplatePersonalData + "/{id:long}", PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetByIdAsync);
            app.MapPost(TemplatePersonalData, PersonalDataEndpoint.PersonalDataWriteOnlyEndpoint.PostAsync);
            app.MapPut(TemplatePersonalData, PersonalDataEndpoint.PersonalDataWriteOnlyEndpoint.PutAsync);
            app.MapDelete(TemplatePersonalData + "/{id:long}", PersonalDataEndpoint.PersonalDataWriteOnlyEndpoint.DeleteAsync);
            app.MapPost(TemplateUser + "/Login", UserWriteOnlyEndpoint.LoginAsync);
            app.MapPost(TemplateUser, UserWriteOnlyEndpoint.CreateUserAsync);

        }
    }
}
