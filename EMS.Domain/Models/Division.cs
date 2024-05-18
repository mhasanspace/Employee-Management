using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Division
    {
        public Division()
        {
            Districts = new HashSet<District>();
            Thanas = new HashSet<Thana>();
        }

        public int Id { get; set; }
        public string DivisionName { get; set; } = null!;
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
    }
}
