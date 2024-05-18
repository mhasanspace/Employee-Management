using EMS.Domain.DtoModels;
using EMS.Domain.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.IRepository
{
    public interface IAuthenticateUserRepository : IRepositoryBase<AppUserLoginInfo>
    {
        AppUserLoginInfo Authenticate(UserLoginDto loginModel);
    }
}
