using Plc.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Dtos;

namespace Plc.Data.Abstract
{
    public interface IPlcRepository : IEntityRepository<Plc.Entities.Concrete.Plc>
    {
        List<PlcDto> GetPlcDto();
    }
}
