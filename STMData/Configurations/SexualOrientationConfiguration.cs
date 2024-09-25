using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STMDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMData.Database.Configurations
{
    public class SexualOrientationConfiguration : IEntityTypeConfiguration<SexualOrientation>
    {
        public void Configure(EntityTypeBuilder<SexualOrientation> builder)
        {
            builder.ToTable("SexualOrientation");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
