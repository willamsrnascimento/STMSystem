using Microsoft.AspNetCore.Identity;
using STMData;

namespace STMApi.Security
{
    public static class SecurityConfigure
    {
        public static void AddSecurityConfigure(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;

            }).AddEntityFrameworkStores<STMDbContext>();
        }
    }
}
