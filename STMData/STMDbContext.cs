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
        public DbSet<Address> Addresses { get; set; }

        public STMDbContext(DbContextOptions<STMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PersonalDataConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new EducationConfiguration());
            builder.ApplyConfiguration(new FamilyDataConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new MaritalStatusConfiguration());
            builder.ApplyConfiguration(new SexualOrientationConfiguration());
            builder.ApplyConfiguration(new SocialBenefitsConfiguration());

        }

    }
}
