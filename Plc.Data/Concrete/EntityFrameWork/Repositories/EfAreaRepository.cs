using Microsoft.EntityFrameworkCore;
using Plc.Data.Abstract;
using Plc.Entities.Concrete;
using Plc.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Data.Concrete.EntityFrameWork.Repositories
{
   public class EfAreaRepository:EfEntityRepositoryBase<Area>,IAreaRepository
    {
        public EfAreaRepository(DbContext context):base(context)
        {

        }
    }
}
