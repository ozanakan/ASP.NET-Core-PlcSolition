using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Concrete;
using Plc.Shared.Entities.Abstract;

namespace Plc.Entities.Dtos
{
    public class AreaDto : DtoGetBase
    {
        public Area Area { get; set; }
    }
}
