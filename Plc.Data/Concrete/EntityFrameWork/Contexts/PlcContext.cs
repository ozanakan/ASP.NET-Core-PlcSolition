using Microsoft.EntityFrameworkCore;
using Plc.Data.Concrete.EntityFrameWork.Mappings;
using Plc.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Plc.Data.Concrete.EntityFrameWork.Contexts
{
   public class PlcContext :IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>  // :DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<WorkCenter> WorkCenters { get; set; }
        public DbSet<Plc.Entities.Concrete.Plc> Plcs { get; set; }
        public DbSet<PlcTag> PlcTags { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Area> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PU7I8L5;database=Plc;trusted_connection=true;Integrated Security=TRUE;MultipleActiveResultSets = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new WorkCenterMap());
            modelBuilder.ApplyConfiguration(new PlcMap());
            modelBuilder.ApplyConfiguration(new PlcTagMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
            
            
        }
    }
}
