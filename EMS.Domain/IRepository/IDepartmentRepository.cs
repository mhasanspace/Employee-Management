using EMS.Domain.Models;
using EMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.IRepository
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        List<DepartmentView> GetDepartmentList(string? searchTerm);
        List<DepartmentView> GetAllDepartment();
        DepartmentView GetDepartmentById(int orgDivId);
        void Add(Department department);
    }
}
