namespace STMApi.Endpoints
{
    public static class EndpointsConfigure
    {
        private static string Template = "/PersonalDatas";
        public static void EndpointConfigure(this WebApplication app)
        {
            app.MapGet(Template, PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetAllAsync);
            app.MapGet(Template + "{id:long}", PersonalDataEndpoint.PersonalDataReadOnlyEndpoint.GetByIdAsync);
        }
    }
}
