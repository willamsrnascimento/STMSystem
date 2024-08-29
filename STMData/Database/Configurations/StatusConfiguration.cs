using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");
            builder.HasKey(s => s.Id);
            builder.Ignore(s => s.StatusId);
            builder.Ignore(s => s.Status);
            builder.Property(s => s.Detail)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(s => s.StatusCode)
                .IsRequired();
        }
    }
}
