using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STMData.Database.Configurations;
using STMDomain.Domain;

namespace STMData
{
    public class STMDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PersonalData> PersonalDatas { get; set; }

        public STMDbContext(DbContextOptions<STMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PersonalDataconfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
        }

    }
}
