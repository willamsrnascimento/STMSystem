using Microsoft.Extensions.DependencyInjection;
using STMComunication.Services.Implementations;
using STMComunication.Services.Interfaces;

namespace STMComunication.DependencyInjection
{
    public static class DependencyInjectionApiConfigure
    {
        public static void AddDependencyInjectionApi(this IServiceCollection services)
        {
            services.AddScoped<IPersonalDataService, PersonalDataService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISocialBenefitsService, SocialBenefitsService>();
        }
    }
}
