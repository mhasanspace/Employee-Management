using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            MenuAccesses = new HashSet<MenuAccess>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public int? IsDelete { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual ICollection<MenuAccess> MenuAccesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
