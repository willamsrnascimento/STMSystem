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
    internal class GenderIdentityConfiguration : IEntityTypeConfiguration<GenderIdentity>
    {
        public void Configure(EntityTypeBuilder<GenderIdentity> builder)
        {
            builder.ToTable("GenderIdentity");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
