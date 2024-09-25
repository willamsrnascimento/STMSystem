using Microsoft.Extensions.DependencyInjection;
using STMData.Repositories;
using STMData.Repositories.Interfaces;

namespace STMData.DependencyInjection
{
    public static class DependencyInjectionDataConfigure
    {
        public static void AddDependencyInjectionData(this IServiceCollection services)
        {
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<ISocialBenefitsRepository, SocialBenefitsRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IFamilyDataRepository, FamilyDataRepository>();
        }
    }
}
