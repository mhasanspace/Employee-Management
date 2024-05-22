using EMS.Common.CommonHelper;
using EMS.Common.EnumUtility;
using EMS.Domain;
using EMS.Domain.DtoModels;
using EMS.Domain.Models;
using EMS.Domain.OtherModels;
using EMS.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static EMS.Common.EnumUtility.EnumCollection;

namespace EMS.Business.Services
{
    public class OrgDivisionService : ServiceBase
    {

        private readonly ILogger<OrgDivisionService> _logger;
        private readonly IConfiguration _configuration;

        public OrgDivisionService(IUnitOfWork unitOfWork, ILogger<OrgDivisionService> logger, IConfiguration configuration) : base(unitOfWork)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public List<OrgDivisionView> GetOrgDivisionListByPage(string? searchTerm)
        {
            try
            {
                List<OrgDivisionView> data = UnitOfWorkSB.OrgDivisionRepository.GetOrgDivisionList(searchTerm);

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrgDivisionService->GetOrgDivisionListByPage. Exception Message : {ex.Message}");
                _logger.LogTrace(ex, ex.Message);
                throw;
            }

        }


        public List<OrgDivisionView> GetAllOrgDivision()
        {
            try
            {
                List<OrgDivisionView> data = UnitOfWorkSB.OrgDivisionRepository.GetAllOrgDivision();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrgDivisionService->GetAllOrgDivision. Exception Message : {ex.Message}");
                _logger.LogTrace(ex, ex.Message);
                throw;
            }

        }

        public OrgDivisionView GetOrgDivisionById(int orgDivId)
        {
            return UnitOfWorkSB.OrgDivisionRepository.GetOrgDivisionById(orgDivId);
        }



        public DotNetRunner AddOrgDivision(OrgDivisionDto orgDivisionDto, AppUserLoginInfo appUserLoginInfo)
        {
            DotNetRunner dotNetRunner = new DotNetRunner();

            OrgDivision orgDivision = new OrgDivision();
            try
            {
                var existingParameterName = UnitOfWorkSB.OrgDivisionRepository.FindOne(d => d.Name.Equals(orgDivisionDto.Name));

                if (existingParameterName != null)
                {
                    dotNetRunner.OperationTypeInfoId = (int)EnumCollection.OperationTypeInfoEnum.DuplicatedData;
                    dotNetRunner.Message = OperationMessage.DuplicateNameMsg;
                    return dotNetRunner;
                }

                orgDivision.Name = orgDivisionDto.Name;
                orgDivision.Status = (int)EnumCollection.CommonStatusEnum.Active;
                orgDivision.IsDelete = (int)EnumCollection.CommonDeleteStatusEnum.NotDeleted;
                orgDivision.CreateBy = appUserLoginInfo.UserId;
                orgDivision.CreateDate = DateTime.Now;

                UnitOfWorkSB.OrgDivisionRepository.Add(orgDivision);
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


        public DotNetRunner UpdateOrgDivision(OrgDivisionDto orgDivisionDto, AppUserLoginInfo appUserLoginInfo)
        {
            DotNetRunner dotNetRunner = new DotNetRunner();

            try
            {
                var existingOrgDivision = UnitOfWorkSB.OrgDivisionRepository.Where(od => od.Id == orgDivisionDto.Id).FirstOrDefault();
                if (existingOrgDivision == null)
                {
                    dotNetRunner.OperationTypeInfoId = (int)EnumCollection.OperationTypeInfoEnum.UpdateOperationError;
                    dotNetRunner.Message = "Data not found or you don't have permission to edit.";
                    return dotNetRunner;
                }

                existingOrgDivision.Name = orgDivisionDto.Name;
                existingOrgDivision.LastModifyBy = appUserLoginInfo.UserId;
                existingOrgDivision.LastModifyDate = DateTime.Now;

                UnitOfWorkSB.OrgDivisionRepository.Update(existingOrgDivision);
                UnitOfWorkSB.SaveChanges();
                dotNetRunner.Message = OperationMessage.UpdateSuccessMsg;
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.Updated;
            }
            catch (Exception ex)
            {
                dotNetRunner.ErrorMessage = ex.Message;
            }

            return dotNetRunner;
        }


        public DotNetRunner DeleteOrgDivision(int orgDivId)
        {
            DotNetRunner dotNetRunner = new DotNetRunner();

            OrgDivision orgDivision = UnitOfWorkSB.OrgDivisionRepository.FindOne(s => s.Id == orgDivId);
            if (orgDivision == null)
            {
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
                dotNetRunner.Message = OperationMessage.InvalidOperationMsg;
                dotNetRunner.ErrorMessage = OperationMessageError.DataNotFoundForDeleteMsg;
                return dotNetRunner;
            }

            // Check if the department is referenced in other tables
            if (IsDepartmentReferenced(orgDivId))
            {
                dotNetRunner.OperationTypeInfoId = (int)OperationTypeInfoEnum.DeleteOperationError;
                dotNetRunner.Message = "Cannot delete division as it is referenced in other records.";
                dotNetRunner.ErrorMessage = "This data is referenced in other tables.";
                return dotNetRunner;
            }


            try
            {
                UnitOfWorkSB.OrgDivisionRepository.Remove(orgDivision);
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


        //This method checks if the department is referenced in other tables.
        private bool IsDepartmentReferenced(int orgDivId)
        {
            return UnitOfWorkSB.DepartmentRepository.Exists(e => e.OrgDivisionId == orgDivId);
        }



    }
}
