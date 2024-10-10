using STMApi.Endpoints.SocialBenefitsEndpoint;
using STMComunication.Endpoints.PersonalDataEndpoint;
using STMComunication.Endpoints.UserEndpoint;

namespace STMComunication.Endpoints
{
    public static class EndpointsConfigure
    {
        private const string TemplatePersonalData = "/PersonalDatas";
        private const string TemplateUser = "/User";
        private const string TemplateSocialBenefits = "/SocialBenefits";
        public static void EndpointConfigure(this WebApplication app)
        {
            app.MapGet(TemplatePersonalData, PersonalDataReadOnlyEndpoint.GetAllAsync);
            app.MapGet(TemplatePersonalData + "/{id:long}", PersonalDataReadOnlyEndpoint.GetByIdAsync);
            app.MapPost(TemplatePersonalData, PersonalDataWriteOnlyEndpoint.PostAsync);
            app.MapPut(TemplatePersonalData, PersonalDataWriteOnlyEndpoint.PutAsync);
            app.MapDelete(TemplatePersonalData + "/{id:long}", PersonalDataWriteOnlyEndpoint.DeleteAsync);
            app.MapPost(TemplateUser + "/Login", UserWriteOnlyEndpoint.LoginAsync);
            app.MapPost(TemplateUser, UserWriteOnlyEndpoint.CreateUserAsync);
            app.MapGet(TemplateSocialBenefits, SocialBenefitsReadOnlyEndpoint.GetAllAsync);
            app.MapGet(TemplateSocialBenefits + "/{id:long}", SocialBenefitsReadOnlyEndpoint.GetByIdAsync);
            app.MapPost(TemplateSocialBenefits, SocialBenefitsWriteOnlyEndpoint.Create);

        }
    }
}
