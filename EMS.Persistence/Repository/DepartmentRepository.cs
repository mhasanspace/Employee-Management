using EMS.Domain.IRepository;
using EMS.Domain.Models;
using EMS.Domain.ViewModels;
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

        public List<DepartmentView> GetAllDepartment()
        {
            List<DepartmentView> departmentViews = new List<DepartmentView>();

            try
            {
                var query = from dep in context.Departments
                            join ord in context.OrgDivisions on dep.OrgDivisionId equals ord.Id
                            join auc in context.Users on dep.CreateBy equals auc.Id
                            join aum in context.Users on dep.LastModifyBy equals aum.Id into lastModifyJoin
                            from aum in lastModifyJoin.DefaultIfEmpty()
                            select new DepartmentView
                            {
                                Id = dep.Id,
                                OrgDivisionId = dep.OrgDivisionId,
                                OrgDivisionName = ord.Name,
                                DepartmentName = dep.DepartmentName,
                                DepartmentCode = dep.DepartmentCode,
                                Status = dep.Status,
                                IsDelete = dep.IsDelete,
                                CreateDate = ord.CreateDate.HasValue ? ord.CreateDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                CreateBy = auc != null ? $"{auc.FirstName} {auc.LastName}" : "",
                                LastModifyDate = ord.LastModifyDate.HasValue ? ord.LastModifyDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                LastModifyBy = aum != null ? $"{aum.FirstName} {aum.LastName}" : ""
                            };

                query = query.OrderByDescending(od => od.Id);

                departmentViews = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return departmentViews ?? new List<DepartmentView>();
        }

        public DepartmentView GetDepartmentById(int orgDivId)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentView> GetDepartmentList(string? searchTerm)
        {
            List<DepartmentView> departmentViews = new List<DepartmentView>();

            try
            {
                var query = from dep in context.Departments
                            join ord in context.OrgDivisions on dep.OrgDivisionId equals ord.Id
                            join auc in context.Users on dep.CreateBy equals auc.Id
                            join aum in context.Users on dep.LastModifyBy equals aum.Id into lastModifyJoin
                            from aum in lastModifyJoin.DefaultIfEmpty()
                            select new DepartmentView
                            {
                                Id = dep.Id,
                                OrgDivisionId = dep.OrgDivisionId,
                                OrgDivisionName = ord.Name,
                                DepartmentName = dep.DepartmentName,
                                DepartmentCode = dep.DepartmentCode,
                                Status = dep.Status,
                                IsDelete = dep.IsDelete,
                                CreateDate = ord.CreateDate.HasValue ? ord.CreateDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                CreateBy = auc != null ? $"{auc.FirstName} {auc.LastName}" : "",
                                LastModifyDate = ord.LastModifyDate.HasValue ? ord.LastModifyDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                LastModifyBy = aum != null ? $"{aum.FirstName} {aum.LastName}" : ""
                            };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(x => x.DepartmentName.Contains(searchTerm) || x.DepartmentCode.Contains(searchTerm) || x.OrgDivisionName.Contains(searchTerm));
                }

                query = query.OrderByDescending(od => od.Id);

                departmentViews = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return departmentViews ?? new List<DepartmentView>();
        }




        void IDepartmentRepository.Add(Department department)
        {
            _context.Set<Department>().Add(department);
        }




    }
}
