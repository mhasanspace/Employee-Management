using EMS.Common.CommonHelper;
using EMS.Common.EnumUtility;
using EMS.Domain;
using EMS.Domain.DtoModels;
using EMS.Domain.Models;
using EMS.Domain.OtherModels;
using EMS.Domain.ViewModels;
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



        public List<DepartmentView> GetAllDepartment()
        {
            try
            {
                List<DepartmentView> data = UnitOfWorkSB.DepartmentRepository.GetAllDepartment();

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"DepartmentService->GetAllDepartment. Exception Message : {ex.Message}");
                _logger.LogTrace(ex, ex.Message);
                throw;
            }

        }


        public List<DepartmentView> GetDepartmentListByPage(string? searchTerm)
        {
            try
            {
                List<DepartmentView> data = UnitOfWorkSB.DepartmentRepository.GetDepartmentList(searchTerm);

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"DepartmentService->GetDepartmentListByPage. Exception Message : {ex.Message}");
                _logger.LogTrace(ex, ex.Message);
                throw;
            }

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




        public DotNetRunner DeleteDepartment(int deptId)
        {
            DotNetRunner dotNetRunner = new DotNetRunner();

            Department department = UnitOfWorkSB.DepartmentRepository.FindOne(d => d.Id == deptId);
            if (department == null)
            {
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
                dotNetRunner.Message = OperationMessage.InvalidOperationMsg;
                dotNetRunner.ErrorMessage = OperationMessageError.DataNotFoundForDeleteMsg;
                return dotNetRunner;
            }

            // Check if the department is referenced in other tables
            //if (IsDepartmentReferenced(deptId))
            //{
            //    dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
            //    dotNetRunner.Message = "Cannot delete department as it is referenced in other records.";
            //    dotNetRunner.ErrorMessage = "Department is referenced in other tables.";
            //    return dotNetRunner;
            //}

            try
            {
                UnitOfWorkSB.DepartmentRepository.Remove(department);
                int result = UnitOfWorkSB.SaveChanges();
                if (result == 1)
                {
                    dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.Deleted;
                    dotNetRunner.Message = OperationMessage.DeleteSuccessMsg;
                }
                else
                {
                    dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
                    dotNetRunner.Message = OperationMessage.DeleteFailMsg;
                }
            }
            catch (Exception ex)
            {
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
                dotNetRunner.Message = OperationMessageError.ExceptionDeleteMsg;
                dotNetRunner.ErrorMessage = ex.Message;
            }

            return dotNetRunner;
        }

        // This method checks if the department is referenced in other tables.
        //private bool IsDepartmentReferenced(int deptId)
        //{
        //    return UnitOfWorkSB.AuthenticateUserRepository.Exists(e => e.DepartmentId == deptId);
        //}




    }
}
