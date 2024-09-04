using STMApi.Services.Implementations;
using STMApi.Services.Interfaces;

namespace STMApi.DependencyInjection
{
    public static class DependencyInjectionApiConfigure
    {
        public static void AddDependencyInjectionApi(this IServiceCollection services)
        {
            services.AddScoped<IPersonalDataService, PersonalDataService>();
            services.AddScoped<UserService>();
        }
    }
}
