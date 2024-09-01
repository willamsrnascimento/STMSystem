using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    public class SocialProgramConfiguration : IEntityTypeConfiguration<SocialProgram>
    {
        public void Configure(EntityTypeBuilder<SocialProgram> builder)
        {
            builder.ToTable("SocialProgrma");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(s => s.Detail)
                .IsRequired(false)
                .HasMaxLength(650);

            builder.Property(s => s.EndDate)
                .HasDefaultValue(null);

            builder.HasMany(s => s.PersonalDatas)
                .WithMany(p => p.SocialPrograms);
             
        }
    }
}
