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
    public class PersonalDataconfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("PersonalData");
            builder.HasKey(x => x.Id);
            //builder.Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(255);
            //builder.Property(p => p.Age)
            //    .IsRequired()
            //    .HasPrecision(1, 120);
            //builder.Property(p => p.BirthdayDate)
            //    .IsRequired();
        }
    }
}
