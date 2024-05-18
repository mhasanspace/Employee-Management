using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuAccesses = new HashSet<MenuAccess>();
        }

        public int Id { get; set; }
        public int MenuParentId { get; set; }
        public int MenuSerialNo { get; set; }
        public string ManuName { get; set; } = null!;
        public string RouteUrl { get; set; } = null!;
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual ICollection<MenuAccess> MenuAccesses { get; set; }
    }
}
