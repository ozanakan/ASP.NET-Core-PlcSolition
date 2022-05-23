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
    public class PlcManager : IPlcService
    {
        public readonly IUnitOfWork _unitOfWork;
        public PlcManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDataResult<Entities.Concrete.Plc> Get(int plcId)
        {
            var plc = _unitOfWork.Plcs.Get(c => c.Id == plcId);
            if (plc != null)
            {
                return new DataResult<Entities.Concrete.Plc>(ResultStatus.Success, plc);
            }
            return new DataResult<Entities.Concrete.Plc>(ResultStatus.Error, "Hata", null);
        }
        public IDataResult<List<Entities.Concrete.Plc>> GetAll()
        {
            var listPlc = _unitOfWork.Plcs.GetAll(null);
            if (listPlc.Count > -1)
            {
                return new DataResult<List<Entities.Concrete.Plc>>(ResultStatus.Success, listPlc);
            }
            return new DataResult<List<Entities.Concrete.Plc>>(ResultStatus.Error, "Hata", null);

        }
        public IResult Add(Entities.Concrete.Plc plc)
        {
            _unitOfWork.Plcs.Add(new Entities.Concrete.Plc
            {
                Name = plc.Name,
                WorkCenterId = plc.WorkCenterId,
                ConnType = plc.ConnType,
                Ip = plc.Ip,
                Slot = plc.Slot
            });
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{plc.Name} adlı Plc başarıyla eklenmiştir.");

        }
        public IResult Update(Entities.Concrete.Plc plc)
        {
            var plcResult = _unitOfWork.Plcs.Get(c => c.Id == plc.Id);
            if (plcResult != null)
            {
                plcResult.Name = plc.Name;
                plcResult.WorkCenterId = plc.WorkCenterId;
                plcResult.ConnType = plc.ConnType;
                plcResult.Ip = plc.Ip;
                plcResult.Slot = plc.Slot;

                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{plc.Name} adlı Plc başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);

        }
        public IResult Delete(Entities.Concrete.Plc plc)
        {
            var plcResult = _unitOfWork.Plcs.Get(c => c.Id == plc.Id);
            if (plcResult != null)
            {
                _unitOfWork.Plcs.Delete(plcResult);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{plc.Name} adlı Plc başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);

        }
    }
}
