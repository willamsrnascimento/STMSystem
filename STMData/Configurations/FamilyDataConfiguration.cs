using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;

namespace STMData.Database.Configurations
{
    public class FamilyDataConfiguration : IEntityTypeConfiguration<FamilyData>
    {
        public void Configure(EntityTypeBuilder<FamilyData> builder)
        {
            builder.ToTable("FamilyData");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.ChildrenQuantity)
                .HasDefaultValue(0)
                .HasPrecision(0, 20);

            builder.Property(f => f.ResidenceQuantity)
                .HasDefaultValue(0)
                .HasPrecision(0, 20);

            builder.Property(f => f.FamilyRevenue)
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

        }
    }
}
