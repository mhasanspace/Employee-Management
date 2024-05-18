using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class User
    {
        public User()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public int? UserTypeId { get; set; }
        public int? UserGroupId { get; set; }
        public int? OrgDivisionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Designation? Designation { get; set; }
        public virtual OrgDivision? OrgDivision { get; set; }
        public virtual UserGroup? UserGroup { get; set; }
        public virtual UserType? UserType { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
