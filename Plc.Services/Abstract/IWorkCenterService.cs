using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Concrete;
using Plc.Shared.Utilities.Results.Abstract;

namespace Plc.Services.Abstract
{
    public interface IWorkCenterService
    {
        IDataResult<WorkCenter> Get(int workCenterId);
        IDataResult<List<WorkCenter>> GetAll();
        IResult Add(WorkCenter workCenter);
        IResult Update(WorkCenter workCenter);
        IResult Delete(WorkCenter workCenter);
    }
}
