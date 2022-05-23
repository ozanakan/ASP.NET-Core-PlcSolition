using Plc.Data.Abstract;
using Plc.Data.Concrete.EntityFrameWork.Contexts;
using Plc.Data.Concrete.EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlcContext _context;
        private EfAreaRepository _areaRepository;
        private EfWorkCenterRepository _workCenterRepository;
        private EfPlcRepository _plcRepository;
        private EfPlcTagRepository _plcTagRepository;
        //private EfUserRepository _userRepository;
        //private EfRoleRepository _roleRepository;



        public UnitOfWork(PlcContext context)
        {
            _context = context;
        }

        
        public IAreaRepository Areas => _areaRepository ?? new EfAreaRepository(_context);

        public IWorkCenterRepository WorkCenters => _workCenterRepository ?? new EfWorkCenterRepository(_context);

        public IPlcRepository Plcs => _plcRepository ?? new EfPlcRepository(_context);

        public IPlcTagRepository PlcTags => _plcTagRepository ?? new EfPlcTagRepository(_context);

        //public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

        //public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
