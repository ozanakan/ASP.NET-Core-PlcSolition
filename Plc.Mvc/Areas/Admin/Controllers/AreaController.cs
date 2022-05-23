using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Plc.Entities.Dtos;
using Plc.Mvc.Areas.Admin.Models;
using Plc.Services.Abstract;
using Plc.Shared.Utilities.Extensions;
using Plc.Shared.Utilities.Results.ComplexTypes;

namespace Plc.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaController : Controller
    {

        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        public IActionResult Index()
        {
            var result = _areaService.GetAll();
            //if (result.ResultStatus == ResultStatus.Success)
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_AreaAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(AreaAddDto areaAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = _areaService.Add(areaAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var areaAddAjaxModel = JsonSerializer.Serialize(new AreaAddAjaxViewModel
                    {
                        AreaDto = result.Data,
                        AreaAddPartial = await this.RenderViewToStringAsync("_AreaAddPartial", areaAddDto)
                    });
                    return Json(areaAddAjaxModel);
                }
            }
            var areaAddAjaxError = JsonSerializer.Serialize(new AreaAddAjaxViewModel
            {
                AreaAddPartial = await this.RenderViewToStringAsync("_AreaAddPartial", areaAddDto)
            });
            return Json(areaAddAjaxError);
        }
        public JsonResult GetAllArea()
        {
            var result = _areaService.GetAll();
            var area = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(area);
        }
        public JsonResult Delete(int areaId)
        {
            var result = _areaService.Delete(areaId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
       
        [HttpGet]
        public IActionResult Update(int areaId)
        {
            var result = _areaService.GetAreaUpdateDto(areaId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_AreaUpdatePartial", result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AreaUpdateDto areaUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = _areaService.Update(areaUpdateDto);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var areaUpdateAjaxModel = JsonSerializer.Serialize(new AreaUpdateAjaxViewModel
                    {
                        AreaDto = result.Data,
                        AreaUpdatePartial = await this.RenderViewToStringAsync("_AreaUpdatePartial",areaUpdateDto)
                    });
                    return Json(areaUpdateAjaxModel);
                }
            }
            var areaUpdateAjaxError = JsonSerializer.Serialize(new AreaUpdateAjaxViewModel
            {
                AreaUpdatePartial = await this.RenderViewToStringAsync("_AreaUpdatePartial",areaUpdateDto)
            });
            return Json(areaUpdateAjaxError);
        }




    }
}
