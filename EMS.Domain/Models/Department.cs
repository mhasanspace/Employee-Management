using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Department
    {
        public Department()
        {
            Designations = new HashSet<Designation>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? OrgDivisionId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string DepartmentCode { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual OrgDivision? OrgDivision { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
