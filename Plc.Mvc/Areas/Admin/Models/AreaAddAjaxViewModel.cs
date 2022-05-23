using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plc.Entities.Dtos;

namespace Plc.Mvc.Areas.Admin.Models
{
    public class AreaAddAjaxViewModel
    {
        public  AreaAddDto AreaAddDto { get; set; }
        public string AreaAddPartial { get; set; }
        public AreaDto AreaDto { get; set; }
    }
}
