using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Thana
    {
        public int Id { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public string ThanaName { get; set; } = null!;
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual District? District { get; set; }
        public virtual Division? Division { get; set; }
    }
}
