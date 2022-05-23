using Microsoft.EntityFrameworkCore;
using Plc.Data.Abstract;
using Plc.Entities.Concrete;
using Plc.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Plc.Data.Concrete.EntityFrameWork.Contexts;
using Plc.Entities.Dtos;

namespace Plc.Data.Concrete.EntityFrameWork.Repositories
{
    class EfWorkCenterRepository:EfEntityRepositoryBase<WorkCenter>,IWorkCenterRepository
    {
        public EfWorkCenterRepository(DbContext context):base(context)
        { 
            
        }
        public List<WorkCenterDto> GetWorkCenterDto()
        {
            using (PlcContext plcContext=new PlcContext())
            {
                var result = from a in plcContext.Areas
                    join w in plcContext.WorkCenters
                        on a.Id equals w.AreaId
                    select new WorkCenterDto
                    {
                        Id = w.Id,
                        AreaId = w.AreaId,
                        AreaName = a.Name,
                        Name = w.Name,
                        Description = w.Description
                    };
                return result.ToList();
            }
           
        }

    }
}
