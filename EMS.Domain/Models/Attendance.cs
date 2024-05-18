using System;
using System.Collections.Generic;

namespace EMS.Domain.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public double? TotalWorkingHour { get; set; }
        public int? Status { get; set; }

        public virtual User? User { get; set; }
    }
}
