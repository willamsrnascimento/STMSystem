using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Email)
                .IsRequired(false)
                .HasMaxLength(255);
        }
    }
}
