using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Plc.Entities.Concrete;
using Plc.Entities.Dtos;

namespace Plc.Services.AutoMapper.Profiles
{
    public class AreaProfile:Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaAddDto, Area>();
            CreateMap<AreaUpdateDto, Area>();
            CreateMap<Area, AreaUpdateDto>();
        }
    }
}
