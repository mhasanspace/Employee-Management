using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class MenuAccess
    {
        public MenuAccess()
        {
            OtherMenuAccesses = new HashSet<OtherMenuAccess>();
        }

        public int Id { get; set; }
        public int? UserGroupId { get; set; }
        public int? MenuId { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanViewDetails { get; set; }
        public bool? CanViewList { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanManage { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual Menu? Menu { get; set; }
        public virtual UserGroup? UserGroup { get; set; }
        public virtual ICollection<OtherMenuAccess> OtherMenuAccesses { get; set; }
    }
}
