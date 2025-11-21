using DAL.Configurations.Abstracts;
using DAL.Entities.Abstracts;
using DAL.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Concretes
{

    public class ShipperConfiguration : BaseConfiguration<Shipper>
    {
        public override void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.Property(x => x.ShipperName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ContactInfo)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // Seed data - varsayılan kargo firmaları
            builder.HasData(
                new Shipper { ID = 1, ShipperName = "MNG Kargo", ContactInfo = "0850 222 0 606", IsActive = true },
                new Shipper { ID = 2, ShipperName = "Yurtiçi Kargo", ContactInfo = "444 99 99", IsActive = true },
                new Shipper { ID = 3, ShipperName = "Aras Kargo", ContactInfo = "444 25 52", IsActive = true },
                new Shipper { ID = 4, ShipperName = "PTT Kargo", ContactInfo = "444 1 788", IsActive = true },
                new Shipper { ID = 5, ShipperName = "Sürat Kargo", ContactInfo = "444 0 078", IsActive = true }
            );

            base.Configure(builder);
        }
    }
}
