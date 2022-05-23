using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Entities.Concrete;
using Plc.Entities.Dtos;
using Plc.Shared.Utilities.Results.Abstract;

namespace Plc.Services.Abstract
{
    public interface IAreaService
    { 
        IDataResult<AreaDto> Get(int areaId);
        IDataResult<AreaUpdateDto> GetAreaUpdateDto(int areaId);
        IDataResult<AreaListDto> GetAll();
        IDataResult<AreaDto> Add(AreaAddDto areaAddDto);
        IDataResult<AreaDto> Update(AreaUpdateDto areaUpdateDto);
        IResult  Delete(int areaId);    
    }
}
