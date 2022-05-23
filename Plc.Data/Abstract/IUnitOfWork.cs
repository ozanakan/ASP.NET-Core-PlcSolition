using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Data.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IAreaRepository Areas { get; }
        IWorkCenterRepository WorkCenters { get; }
        IPlcRepository Plcs { get; }
        IPlcTagRepository PlcTags { get; }
        //IUserRepository Users { get; }
        //IRoleRepository Roles { get; }

        int Save();//kayıt işlemi
    }
}
