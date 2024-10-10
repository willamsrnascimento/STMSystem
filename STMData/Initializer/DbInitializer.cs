using Microsoft.AspNetCore.Identity;
using STMData.Initializer.Interfaces;
using STMData.Security;
using System.Security.Claims;
using System.Security.Cryptography;

namespace STMData.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private const string role_admin = "admin";
        private const string role_standard = "standard";
        private const string admin_password = "$Tm@dm!n5160";
        private const string admin_claim_name = "STM Administrador";

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_userManager.FindByNameAsync("stm-admin").Result == null)
            {

                IdentityUser identityUser = new IdentityUser
                {
                    UserName = "stm-admin",
                    Email = "stm-admin@stm.com.br",
                    EmailConfirmed = true,
                    PhoneNumber = "+55 (81) 12345-6789",
                };

                _ = _roleManager.CreateAsync(new IdentityRole(role_admin)).GetAwaiter().GetResult();
                _ = _roleManager.CreateAsync(new IdentityRole(role_standard)).GetAwaiter().GetResult();
                _ = _userManager.CreateAsync(identityUser, SecurityUtils.ComputeHash(admin_password, SHA256.Create())).GetAwaiter().GetResult();
                _ = _userManager.AddToRoleAsync(identityUser, role_admin).GetAwaiter().GetResult();
                _ = _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Name, admin_claim_name)).GetAwaiter().GetResult();
            }
        }
    }
}
