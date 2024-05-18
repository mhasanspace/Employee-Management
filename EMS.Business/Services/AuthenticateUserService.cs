using EMS.Business.OtherServices;
using EMS.Domain;
using EMS.Domain.DtoModels;
using EMS.Domain.OtherModels;
using EMS.Persistence.DBaseContext;
using Microsoft.Extensions.Logging;

namespace EMS.Business.Services
{
    public class AuthenticateUserService : ServiceBase
    {
        private readonly EmsDbContext _context;
        private readonly ILogger<AuthenticateUserService> _logger;
        private readonly TokenService _tokenService;
        public AuthenticateUserService(IUnitOfWork unitOfWork, EmsDbContext context, ILogger<AuthenticateUserService> logger, TokenService tokenService) : base(unitOfWork)
        {
            _logger = logger;
            _tokenService = tokenService;
            _context = context;
        }

        /// <summary>
        /// Authenticate User With UserName, Password and Generate JWT GenerateToken
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public AppUserLoginInfo Authenticate(UserLoginDto loginModel)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password);

            if (user == null)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(user);

            var userType = _context.UserTypes.FirstOrDefault(ut => ut.Id == user.UserTypeId);
            var userGroup = _context.UserGroups.FirstOrDefault(ug => ug.Id == user.UserGroupId);
            var orgdiv = _context.OrgDivisions.FirstOrDefault(d => d.Id == user.OrgDivisionId);
            var department = _context.Departments.FirstOrDefault(d => d.Id == user.DepartmentId);
            var designation = _context.Designations.FirstOrDefault(d => d.Id == user.DesignationId);

            return new AppUserLoginInfo
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserFullName = $"{user.FirstName} {user.LastName}",
                UserTypeId = user.UserTypeId ?? 0,
                UserTypeName = userType?.TypeName ?? "0",
                UserGroupId = user.UserGroupId ?? 0,
                UserGroupName = userGroup?.GroupName ?? "0",
                OrgdivisionId = user.OrgDivisionId ?? 0,
                OrgdivisionName = orgdiv?.Name ?? "0",
                DepartmentId = user.DepartmentId ?? 0,
                DepartmentName = department?.DepartmentName ?? "0",
                DesignationId = user.DesignationId ?? 0,
                DesignationName = designation?.DesignationName ?? "0",
                JwtTokenValue = token,
            };
        }
        
    }
}
