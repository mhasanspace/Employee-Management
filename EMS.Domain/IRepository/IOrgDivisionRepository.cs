using EMS.Domain.Models;
using EMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.IRepository
{
    public interface IOrgDivisionRepository : IRepositoryBase<OrgDivision>
    {
        void Add(OrgDivision orgDivision);
        List<OrgDivisionView> GetOrgDivisionList(string? searchTerm);
    }
}
