using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.DtoModels
{
    public class OrgDivisionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Status { get; set; }
        public int? IsDelete { get; set; }

    }
}
