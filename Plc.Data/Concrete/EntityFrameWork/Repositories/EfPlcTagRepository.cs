using Microsoft.EntityFrameworkCore;
using Plc.Data.Abstract;
using Plc.Entities.Concrete;
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
    class EfPlcTagRepository : EfEntityRepositoryBase<PlcTag>, IPlcTagRepository
    {
        public EfPlcTagRepository(DbContext context) : base(context)
        {
        }

        public List<PlcTagDto> GetPlcTagDto()
        {
            using (PlcContext plcContext = new PlcContext())
            {
                var result = from w in plcContext.Plcs
                             join p in plcContext.PlcTags
                                 on w.Id equals p.PlcId
                             select new PlcTagDto()
                             {
                                 Id = p.PlcId,
                                 PlcId = p.PlcId,
                                 PlcName = w.Name,
                                 Description =p.Description,
                                 DbNumber = p.DbNumber,
                                 Address = p.Address,
                                 DataType = p.DataType,
                             };
                return result.ToList();
            }

        }

    }
}
