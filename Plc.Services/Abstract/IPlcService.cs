using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Concrete;
using Plc.Shared.Utilities.Results.Abstract;

namespace Plc.Services.Abstract
{
    interface IPlcService
    {
        IDataResult<Entities.Concrete.Plc> Get(int plcId);
        IDataResult<List<Entities.Concrete.Plc>> GetAll();
        IResult Add(Entities.Concrete.Plc plc);
        IResult Update(Entities.Concrete.Plc plc);
        IResult Delete(Entities.Concrete.Plc plc);
    }
}
