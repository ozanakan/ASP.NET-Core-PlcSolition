using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plc.Data.Abstract;
using Plc.Entities.Concrete;
using Plc.Services.Abstract;
using Plc.Shared.Utilities.Results.Abstract;
using Plc.Shared.Utilities.Results.ComplexTypes;
using Plc.Shared.Utilities.Results.Concrete;

namespace Plc.Services.Concrete
{
    class PlcTagManager : IPlcTagService
    {
        public readonly IUnitOfWork _unitOfWork;

        public PlcTagManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IDataResult<PlcTag> Get(int plcTagId)
        {
            var plcTag = _unitOfWork.PlcTags.Get(c => c.Id == plcTagId);
            if (plcTag != null)
            {
                return new DataResult<PlcTag>(ResultStatus.Success, plcTag);
            }
            return new DataResult<PlcTag>(ResultStatus.Error, "Hata", null);
        }
        public IDataResult<List<PlcTag>> GetAll()
        {
            var listPlcTag = _unitOfWork.PlcTags.GetAll(null);
            if (listPlcTag.Count > -1)
            {
                return new DataResult<List<PlcTag>>(ResultStatus.Success, listPlcTag);
            }
            return new DataResult<List<PlcTag>>(ResultStatus.Error, "Hata", null);
        }
        public IResult Add(PlcTag plcTag)
        {
            _unitOfWork.PlcTags.Add(new PlcTag
            {
                Name = plcTag.Name,
                PlcId  = plcTag.Id,
                Address = plcTag.Address,
                DataType =plcTag.DataType,
                DbNumber = plcTag.DbNumber,
                Description = plcTag.Description
            });
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{plcTag.Name} adlı PlcTag başarıyla eklenmiştir.");
        }
        public IResult Update(PlcTag plcTag)
        {
            var plcTagResult = _unitOfWork.PlcTags.Get(c => c.Id == plcTag.Id);
            if (plcTagResult != null)
            {
                plcTagResult.Name = plcTag.Name;
                plcTagResult.PlcId = plcTag.Id;
                plcTagResult.Address = plcTag.Address;
                plcTagResult.DataType = plcTag.DataType;
                plcTagResult.DbNumber = plcTag.DbNumber;
                plcTagResult.Description = plcTag.Description;
                
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{plcTag.Name} adlı PlcTag başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);
        }
        public IResult Delete(PlcTag plcTag)
        {
            var plcTagResult = _unitOfWork.PlcTags.Get(c => c.Id == plcTag.Id);
            if (plcTagResult != null)
            {
                _unitOfWork.PlcTags.Delete(plcTag);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{plcTag.Name} adlı PlcTag başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);
        }

    }
}
