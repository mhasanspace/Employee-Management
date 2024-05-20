using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.DtoModels
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int? OrgDivisionId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string DepartmentCode { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
    }
}
