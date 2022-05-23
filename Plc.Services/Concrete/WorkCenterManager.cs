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
    public class WorkCenterManager : IWorkCenterService
    {
        public readonly IUnitOfWork _unitOfWork;
        public WorkCenterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDataResult<WorkCenter> Get(int workCenterId)
        {
            var workCenter = _unitOfWork.WorkCenters.Get(c => c.Id == workCenterId);
            if (workCenter != null)
            {
                return new DataResult<WorkCenter>(ResultStatus.Success, workCenter);
            }
            return new DataResult<WorkCenter>(ResultStatus.Error, "Hata", null);
        }

        public IDataResult<List<WorkCenter>> GetAll()
        {
            var listWorkCenter = _unitOfWork.WorkCenters.GetAll(null);
            if (listWorkCenter.Count > -1)
            {
                return new DataResult<List<WorkCenter>>(ResultStatus.Success, listWorkCenter);
            }
            return new DataResult<List<WorkCenter>>(ResultStatus.Error, "Hata", null);
        }
        public IResult Add(WorkCenter workCenter)
        {
            _unitOfWork.WorkCenters.Add(new WorkCenter
            {
                Name = workCenter.Name,
                AreaId = workCenter.AreaId,
                Description = workCenter.Description
            });
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{workCenter.Name} adlı WorkCenter başarıyla eklenmiştir.");
        }
        public IResult Update(WorkCenter workCenter)
        {
            var workCenterResult = _unitOfWork.WorkCenters.Get(c => c.Id == workCenter.Id);
            if (workCenterResult != null)
            {
                workCenterResult.Name = workCenter.Name;
                workCenterResult.AreaId = workCenter.AreaId;
                workCenterResult.Description = workCenter.Description;
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{workCenter.Name} adlı WorkCenter başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);
        }
        public IResult Delete(WorkCenter workCenter)
        {
            var workCenterResult = _unitOfWork.WorkCenters.Get(c => c.Id == workCenter.Id);
            if (workCenterResult != null)
            {
                _unitOfWork.WorkCenters.Delete(workCenterResult);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{workCenter.Name} adlı WorkCenter başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata", null);
        }

    }
}
