using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Concrete;
using Plc.Shared.Utilities.Results.Abstract;

namespace Plc.Services.Abstract
{
    interface IPlcTagService
    {
        IDataResult<PlcTag> Get(int plcTagId);
        IDataResult<List<PlcTag>> GetAll();
        IResult Add(PlcTag plcTag);
        IResult Update(PlcTag plcTag);
        IResult Delete(PlcTag plcTag);
    }
}
