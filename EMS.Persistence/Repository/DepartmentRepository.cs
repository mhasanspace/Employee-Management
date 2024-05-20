using EMS.Domain.IRepository;
using EMS.Domain.Models;
using EMS.Persistence.DBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.Repository
{
    public class DepartmentRepository : RepositoryBase<EmsDbContext, Department>, IDepartmentRepository
    {
        private readonly EmsDbContext _context;
        public DepartmentRepository(EmsDbContext context) : base(context)
        {
            _context = context;
        }

        void IDepartmentRepository.Add(Department department)
        {
            _context.Set<Department>().Add(department);
        }

    }
}
