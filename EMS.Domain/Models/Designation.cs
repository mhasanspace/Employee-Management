using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string DesignationName { get; set; } = null!;
        public string DesignationCode { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
