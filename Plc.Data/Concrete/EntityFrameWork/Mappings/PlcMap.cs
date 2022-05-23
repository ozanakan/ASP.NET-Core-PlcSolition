using Microsoft.EntityFrameworkCore;
using Plc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Data.Concrete.EntityFrameWork.Mappings
{
    class PlcMap : IEntityTypeConfiguration<Plc.Entities.Concrete.Plc>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plc.Entities.Concrete.Plc> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(80);
            builder.Property(a => a.Ip).IsRequired();
            builder.Property(a => a.Ip).HasMaxLength(80);
            builder.Property(a => a.Slot).IsRequired();
            builder.Property(a => a.Slot).HasMaxLength(80);
            builder.Property(a => a.ConnType).IsRequired();
            builder.Property(a => a.ConnType).HasMaxLength(80);

            builder.HasOne<WorkCenter>(a => a.WorkCenter).WithMany(c => c.Plcs).HasForeignKey(a => a.WorkCenterId);
            builder.ToTable("Plc");

        }
    }
}
