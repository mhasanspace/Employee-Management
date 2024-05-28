using EMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.OtherModels
{
    public class AppUserLoginInfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserFullName { get; set; }
        public int UserTypeId { get; set; }
        public string? UserTypeName { get; set; }
        public int UserGroupId { get; set; }
        public string? UserGroupName { get; set; }
        public int OrgdivisionId { get; set; }
        public string? OrgdivisionName { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public string? JwtTokenValue { get; set; }



    
}
}
