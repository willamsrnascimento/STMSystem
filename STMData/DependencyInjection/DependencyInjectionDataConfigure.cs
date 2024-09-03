using Microsoft.Extensions.DependencyInjection;
using STMData.Repositories.Implementations;
using STMData.Repositories.Interfaces;

namespace STMData.DependencyInjection
{
    public static class DependencyInjectionDataConfigure
    {
        public static void AddDependencyInjectionData(this IServiceCollection services)
        {
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
        }
    }
}
