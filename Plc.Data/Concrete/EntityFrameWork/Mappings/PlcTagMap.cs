using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Data.Concrete.EntityFrameWork.Mappings
{
    class PlcTagMap : IEntityTypeConfiguration<PlcTag>
    {
        public void Configure(EntityTypeBuilder<PlcTag> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); 
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(80);
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(80);
            builder.Property(a => a.DbNumber).IsRequired();
            builder.Property(a => a.DbNumber).HasMaxLength(80);
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(80);
            builder.Property(a => a.DataType).IsRequired();
            builder.Property(a => a.DataType).HasMaxLength(80);

            builder.HasOne<Plc.Entities.Concrete.Plc>(a => a.Plc).WithMany(c => c.PlcTags).HasForeignKey(a => a.PlcId);
            builder.ToTable("PlcTag");
        }
    }
}
