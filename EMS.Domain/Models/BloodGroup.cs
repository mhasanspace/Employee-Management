using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class BloodGroup
    {
        public int Id { get; set; }
        public string BloodGroupName { get; set; } = null!;
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
