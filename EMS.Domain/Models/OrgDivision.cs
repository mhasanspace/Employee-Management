using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class OrgDivision
    {
        public OrgDivision()
        {
            Departments = new HashSet<Department>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
