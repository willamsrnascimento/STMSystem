using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Place)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
