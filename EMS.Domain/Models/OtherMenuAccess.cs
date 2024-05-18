using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class OtherMenuAccess
    {
        public int Id { get; set; }
        public int? MenuAccessId { get; set; }
        public bool? CanApprove { get; set; }
        public bool? CanReject { get; set; }
        public bool? CanPublish { get; set; }
        public int CreateBy { get; set; }
        public int LastModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        public virtual MenuAccess? MenuAccess { get; set; }
    }
}
