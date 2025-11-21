using DAL.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Abstracts
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseClass
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //Baseclas içerisinde bulunan özelliklerin özelleştirilmesi.
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false);
            builder.Property(x => x.IpAddress).HasMaxLength(128);
        }
    }
}
