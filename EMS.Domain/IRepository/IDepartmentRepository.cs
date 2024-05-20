using EMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.IRepository
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        void Add(Department department);
    }
}
