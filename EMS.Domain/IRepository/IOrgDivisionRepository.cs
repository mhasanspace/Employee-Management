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
       
        List<OrgDivisionView> GetOrgDivisionList(string? searchTerm);
        OrgDivisionView GetOrgDivisionById(int orgDivId);

        void Add(OrgDivision orgDivision);


    }
}
