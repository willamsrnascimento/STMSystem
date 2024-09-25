using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;


namespace STMData.Database.Configurations
{
    public class PersonalDataConfiguration : IEntityTypeConfiguration<PersonalData>
    {
        public void Configure(EntityTypeBuilder<PersonalData> builder)
        {
            builder.ToTable("PersonalData");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.BirthdayDate)
                .IsRequired();

            builder.Property(p => p.Age)
                .IsRequired()
                .HasPrecision(1, 150);

            builder.Property(p => p.Occupancy)
                .HasMaxLength(128);

            builder.Property(p => p.ResponsibleCpf)
                .HasMaxLength(15)
                .IsRequired(false);

            builder.HasMany(p => p.SocialBenefits)
                .WithMany(s => s.PersonalDatas)
                .UsingEntity(
                    "PersonalDataSocialProgram",
                    p => p.HasOne(typeof(SocialBenefits)).WithMany().HasForeignKey("SocialProgramId").HasPrincipalKey(nameof(SocialBenefits.Id)).OnDelete(DeleteBehavior.ClientCascade),
                    s => s.HasOne(typeof(PersonalData)).WithMany().HasForeignKey("PersonalDataId").HasPrincipalKey(nameof(PersonalData.Id)).OnDelete(DeleteBehavior.ClientCascade)
                ); ;

            builder.HasOne(p => p.Education)
                .WithMany(e => e.PersonalDatas)
                .HasForeignKey("EducationId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Gender)
                .WithMany(g => g.PersonalDatas)
                .HasForeignKey("GenderId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.SexualOrientation)
                .WithMany(s => s.PersonalDatas)
                .HasForeignKey("SexualOrientationId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.MaritalStatus)
                .WithMany(m => m.PersonalDatas)
                .HasForeignKey("MaritalStatusId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Contacts)
                .WithOne(c => c.PersonalData)
                .HasForeignKey("PersonalDataId")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(p => p.Address)
                .WithOne(a => a.PersonalData)
                .HasForeignKey<PersonalData>(p => p.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.FamilyData)
                .WithOne(f => f.PersonalData)
                .HasForeignKey<PersonalData>(p => p.FamilyDataId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
