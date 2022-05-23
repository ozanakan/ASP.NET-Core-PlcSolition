using Microsoft.EntityFrameworkCore;
using Plc.Data.Abstract;
using Plc.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Data.Concrete.EntityFrameWork.Contexts;
using Plc.Entities.Dtos;

namespace Plc.Data.Concrete.EntityFrameWork.Repositories
{
    class EfPlcRepository : EfEntityRepositoryBase<Plc.Entities.Concrete.Plc>, IPlcRepository
    {
        public EfPlcRepository(DbContext context) : base(context)
        {
        }

        public List<PlcDto> GetPlcDto()
        {
            using (PlcContext plcContext = new PlcContext())
            {
                var result = from w in plcContext.WorkCenters
                             join p in plcContext.Plcs
                                 on w.Id equals p.WorkCenterId
                             select new PlcDto
                             {
                                 Id = p.Id,
                                 WorkCenterId = p.WorkCenterId,
                                 WorkCenterName = w.Name,
                                 Name = p.Name,
                                 Ip = p.Ip,
                                 Slot = p.Slot,
                                 ConnType = p.ConnType
                             };
                return result.ToList();
            }

        }

    }
}
