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






    }
}
