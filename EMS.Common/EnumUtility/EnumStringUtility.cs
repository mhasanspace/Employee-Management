using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.EnumUtility
{
    public static class GoogleStoreLoginInfo
    {
        public const string GoogleStoreUser = "app_osrms@system.user";
        public const string GoogleStorePhoneNumber = "01741243940";
        public const string GoogleStoreOtpNumber = "202401";
    }

    /// <summary>
    /// It is non changeable data.
    /// </summary>
    public static class GenderTypeChar
    {
        public const string Male = "M";
        public const string Female = "F";
        public const string Common = "C";
    }

    /// <summary>
    /// It is master_orgdivision table data. If any new internal orgination add in this table this name must map here.
    /// </summary>
    public static class OrgInternalDivision
    {
        public const string CEOOffice = "CEO Office";
        public const string Commercial = "Commercial";
        public const string CorporateAndRegulatoryAffairs = "Corporate & Regulatory Affairs";
        public const string EthicsAndCompliance = "Ethics and Compliance";
        public const string Finance = "Finance";
        public const string HumanResourcesAndAdministration = "Human Resources & Administration";
        public const string LegalAffairsAndCompanySecretariat = "Legal Affairs & Company Secretariat";
        public const string Technology = "Technology";

    }


    public static class OperationMessage
    {
        public const string SaveSuccessMsg = "Data is saved successfully.";
        public const string UpdateSuccessMsg = "Data is updated successfully.";
        public const string DeleteSuccessMsg = "Data is deleted successfully.";

        public const string DuplicateNameMsg = "Duplicate name, please check entry name.";
        public const string DuplicateCodeMsg = "Duplicate code, please check entry code.";
        public const string DuplicateResignationMsg = "Already requested for resignation";
        public const string DuplicateMsg = "Duplicate application, please check entry.";

        public const string InvalidOperationMsg = "Invalid operation, Please check entry value.";
        public const string NotDraftDataMsg = "It is not draft stage, It is not possible to delete.";

        public const string SaveFailMsg = "Fail save operation.";
        public const string UpdateFailMsg = "Fail update operation";
        public const string AcceptFailMsg = "Fail accept operation";
        public const string DeleteFailMsg = "Fail delete operation";

        public const string SubmittedSuccessMsg = "Data is submitted successfully.";
        public const string ApprovedSuccessMsg = "Data is approved successfully.";
        public const string RejectedSuccessMsg = "Rejection confirmed.";
        public const string FileNotFound = "File not found";
        public const string NoFilesWereUploaded = "No files were uploaded.";

        public const string UnitDataCouldNotBeDeleted = "This Unit info can't be deleted.";

        public const string PasswordChangeSuccessMsg = "Password changed successfully! Please login with new password";
        public const string PasswordChangeFailMsg = "Old password doesn't match or user not found";

        public const string AlreadyAllocated = "This asset is already allocated. It can not update now.";

    }

    public static class OperationMessageError
    {
        public const string DataNotFoundForUpdateMsg = "Data is not found for update.";
        public const string DataNotFoundForDeleteMsg = "Data is not found for delete.";
        public const string ExceptionUpdateMsg = "Application execution error occur for update data.";
        public const string ExceptionDeleteMsg = "Application execution error occur for delete data.";
        public const string DataAlreadyInUserCannotDelete = "Data already in user. Cannot be deleted";
    }

    public static class OsrProfileStatus
    {
        public const string Incomplete = "Incomplete";
        public const string Active = "Active";
        public const string Inactive = "Inactive";
    }

    public static class SessionStorageName
    {
        public const string AppUserLoginInfo = "AppUserLoginInfo";
        public const string BLEmailServerInfo = "BLEmailServerInfo";
    }

    public static class UserDefaultSetup
    {
        public const string DefaultPassword = "123456";
        public const string SecretKey = "12357";
    }
}
