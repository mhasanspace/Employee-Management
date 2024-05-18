using EMS.Domain.DtoModels;
using EMS.Domain.IRepository;
using EMS.Domain.OtherModels;
using EMS.Persistence.DBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.Repository
{
    public class AuthenticateUserRepository : RepositoryBase<EmsDbContext, AppUserLoginInfo>, IAuthenticateUserRepository
    {
        public AuthenticateUserRepository(EmsDbContext context) : base(context)
        {
        }

        public AppUserLoginInfo Authenticate(UserLoginDto loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
