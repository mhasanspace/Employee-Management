using EMS.Domain;
using EMS.Domain.IRepository;
using EMS.Persistence.DBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EmsDbContext _dbContext;

        
        public UnitOfWork(EmsDbContext context
            , IAuthenticateUserRepository authenticateUserRepository
            , IOrgDivisionRepository orgDivisionRepository
            , IDepartmentRepository departmentRepository
            )
        {
            this._dbContext = context;
            AuthenticateUserRepository = authenticateUserRepository;
            OrgDivisionRepository = orgDivisionRepository;
            DepartmentRepository = departmentRepository;
        }
        public IAuthenticateUserRepository AuthenticateUserRepository { get; set; }

        public IOrgDivisionRepository OrgDivisionRepository { get; set; }

        public IDepartmentRepository DepartmentRepository { get; set; }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
