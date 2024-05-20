using EMS.Common.CommonHelper;
using EMS.Common.EnumUtility;
using EMS.Domain;
using EMS.Domain.DtoModels;
using EMS.Domain.Models;
using EMS.Domain.OtherModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EMS.Common.EnumUtility.EnumCollection;

namespace EMS.Business.Services
{
    public class DepartmentService : ServiceBase
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly IConfiguration _configuration;
        public DepartmentService(IUnitOfWork unitOfWork, ILogger<DepartmentService> logger, IConfiguration configuration) : base(unitOfWork)
        {
            _logger = logger;
            _configuration = configuration;
        }



        public DotNetRunner AddDepartment(DepartmentDto departmentDto, AppUserLoginInfo appUserLoginInfo)
        {
            DotNetRunner dotNetRunner = new DotNetRunner();

            Department department = new Department();
            try
            {
                var existingRecord = UnitOfWorkSB.DepartmentRepository.FindOne(d => (d.DepartmentName.Equals(departmentDto.DepartmentName)) || (d.DepartmentCode.Equals(departmentDto.DepartmentCode)));

                if (existingRecord != null)
                {
                    dotNetRunner.OperationTypeInfoId = (int)EnumCollection.OperationTypeInfoEnum.DuplicatedData;
                    dotNetRunner.Message = OperationMessage.DuplicateNameMsg;
                    return dotNetRunner;
                }

                department.OrgDivisionId = departmentDto.OrgDivisionId;
                department.DepartmentName = departmentDto.DepartmentName;
                department.DepartmentCode = departmentDto.DepartmentCode;
                department.Status = (int)EnumCollection.CommonStatusEnum.Active;
                department.IsDelete = (int)EnumCollection.CommonDeleteStatusEnum.NotDeleted;
                department.CreateBy = appUserLoginInfo.UserId;
                department.CreateDate = DateTime.Now;

                UnitOfWorkSB.DepartmentRepository.Add(department);
                UnitOfWorkSB.SaveChanges();
                dotNetRunner.Message = OperationMessage.SaveSuccessMsg;
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.Saved;
            }
            catch (Exception ex)
            {
                dotNetRunner.ErrorMessage = ex.Message;
            }
            return dotNetRunner;
        }



    }
}
