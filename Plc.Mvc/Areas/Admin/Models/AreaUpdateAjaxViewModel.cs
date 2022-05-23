using Plc.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plc.Mvc.Areas.Admin.Models
{
    public class AreaUpdateAjaxViewModel
    {
        public AreaAddDto AreaUpdateDto { get; set; }
        public string AreaUpdatePartial { get; set; }
        public AreaDto AreaDto { get; set; }
    }
}
