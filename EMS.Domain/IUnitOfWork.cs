using EMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticateUserRepository AuthenticateUserRepository { get; }
        IOrgDivisionRepository OrgDivisionRepository { get; }

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
