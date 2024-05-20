using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.ViewModels
{
    public class DepartmentView
    {
        public int Id { get; set; }
        public int? OrgDivisionId { get; set; }
        public string? OrgDivisionName { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string DepartmentCode { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public string? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? LastModifyBy { get; set; }
        public string? LastModifyDate { get; set; }
    }
}
