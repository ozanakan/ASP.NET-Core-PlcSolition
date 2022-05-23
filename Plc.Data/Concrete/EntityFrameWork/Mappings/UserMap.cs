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
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(u=>u.Id);
            //builder.Property(u=>u.Id).ValueGeneratedOnAdd();
            //builder.Property(u => u.Email).IsRequired();
            //builder.Property(u => u.Email).HasMaxLength(50);
            //builder.HasIndex( u => u.Email).IsUnique();
            //builder.Property(u => u.UserName).IsRequired();
            //builder.Property(u => u.UserName).HasMaxLength(50);
            //builder.HasIndex(u => u.UserName).IsUnique();
            //builder.Property(u => u.PasswordHash).IsRequired();
            //builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            //builder.Property(u => u.FirstName).IsRequired();
            //builder.Property(u => u.FirstName).HasMaxLength(50);
            //builder.Property(u => u.LastName).IsRequired();
            //builder.Property(u => u.LastName).HasMaxLength(50);
            //builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            //builder.ToTable("User");
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(50);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        }
    }
}
