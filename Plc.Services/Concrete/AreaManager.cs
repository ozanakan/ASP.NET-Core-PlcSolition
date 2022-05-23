using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Plc.Data.Abstract;
using Plc.Entities.Concrete;
using Plc.Entities.Dtos;
using Plc.Services.Abstract;
using Plc.Shared.Utilities.Results.Abstract;
using Plc.Shared.Utilities.Results.ComplexTypes;
using Plc.Shared.Utilities.Results.Concrete;

namespace Plc.Services.Concrete
{
    public class AreaManager : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AreaManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IDataResult<AreaDto> Get(int areaId)
        {
            var area = _unitOfWork.Areas.Get(c => c.Id == areaId);
            if (area != null)
            {
                return new DataResult<AreaDto>(ResultStatus.Success, new AreaDto
                {
                    Area = area,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AreaDto>(ResultStatus.Error, "Böyle bir area bulunamadı.", new AreaDto
            {
                Area = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir area bulunamadı."
            });
        }
        public IDataResult<AreaUpdateDto> GetAreaUpdateDto(int areaId)
        {
            var area = _unitOfWork.Areas.Get(c => c.Id == areaId);
            if (area != null)
            {
                var areaUpdateDto = _mapper.Map<AreaUpdateDto>(area);
                return new DataResult<AreaUpdateDto>(ResultStatus.Success, areaUpdateDto);
            }
            return new DataResult<AreaUpdateDto>(ResultStatus.Error, "Böyle Bir Area Bulunamadı.", null);
        }
        public IDataResult<AreaListDto> GetAll()
        {
            var listArea = _unitOfWork.Areas.GetAll(null);
            if (listArea.Count > -1)
            {
                return new DataResult<AreaListDto>(ResultStatus.Success, new AreaListDto
                {
                    Areas = listArea,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AreaListDto>(ResultStatus.Error, "Hiç bir değer bulunamadı", new AreaListDto
            {
                Areas = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir değer bulunamadı."
            });
        }
        public IDataResult<AreaDto> Add(AreaAddDto areaAddDto)
        {
            var area = _mapper.Map<Area>(areaAddDto);
            var addedArea = _unitOfWork.Areas.Add(area);
            _unitOfWork.Save();
            return new DataResult<AreaDto>(
                ResultStatus.Success, $"{areaAddDto.Name} Başarıyla Eklenmiştir.", new AreaDto
                {
                    Area = addedArea,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{areaAddDto.Name} Başarıyla Eklenmiştir."   
                });
        }
        public IDataResult<AreaDto> Update(AreaUpdateDto areaUpdateDto)
        {
            var area = _mapper.Map<Area>(areaUpdateDto);
            var updateArea = _unitOfWork.Areas.Update(area);
            _unitOfWork.Save();
            return new DataResult<AreaDto>(ResultStatus.Success, $"{areaUpdateDto.Name} Başarıyla Güncellenmiştir.", new AreaDto
            {
                Area = updateArea,
                ResultStatus = ResultStatus.Success,
                Message = $"{areaUpdateDto.Name} Başarıyla Eklenmiştir."
            });
        }
        public IResult Delete(int areaId)
        {
            var result = _unitOfWork.Areas.Any(a => a.Id == areaId);
            if (result)
            {
                var area = _unitOfWork.Areas.Get(a => a.Id == areaId);
                _unitOfWork.Areas.Delete(area);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{area.Name} Başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Success, "Böyle bir kayıt bulunamadı.");
        }


    }
}
