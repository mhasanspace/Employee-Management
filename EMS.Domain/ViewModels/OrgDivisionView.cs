using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.ViewModels
{
    public class OrgDivisionView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }
        public string CreateByName { get; set; }
        public string CreateDate { get; set; }
        public string LastModifyByName { get; set; }
        public string LastModifyDate { get; set; }
    }
}
