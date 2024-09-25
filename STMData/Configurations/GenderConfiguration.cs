using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
