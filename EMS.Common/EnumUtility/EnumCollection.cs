using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Common.EnumUtility
{
    public static class EnumCollection
    {
        /// <summary>
        /// Operation Type Info Enum
        /// </summary>
        public enum OperationTypeInfoEnum
        {
            Saved = 1,
            Updated = 2,
            Deleted = 3,
            GetCollection = 4,
            ProcessData = 5,
            DuplicatedData = 6,
            SaveOperationError = 100,
            UpdateOperationError = 101,
            DeleteOperationError = 102,
            SubmitForApproveError = 201,
            ValidData = 301,
            InvalideData = 302
        }

        /// <summary>
        /// Enum For Communly Used Status
        /// </summary>
        public enum CommonStatusEnum
        {
            InActive = 0,
            Active = 1
        }

        public enum CommonDeleteStatusEnum
        {
            Deleted = 0,
            NotDeleted = 1
        }


        /// <summary>
        ///  It is same enum of Vendor.Osrms.Web\ClientApp\src\app\common\static-string-data->enum-collection.ApproveOrRejectEnum
        /// </summary>
        public enum ApproveOrRejectEnum
        {
            Reject = 0,
            Approve = 1
        }

        /// <summary>
        /// This value is mapping value of app_users_type table. type_name_ntv field is enum string and type_default_group field is enum value.
        /// </summary>
        public enum UserTypeEnum
        {
            SuperAdmin = 1,
            BLEmployeeLogin = 2,
            OSREmployeeLogin = 3,
            VendorLogin = 4
        }

        /// <summary>
        /// This value is mapping value of app_users_type table. type_name_ntv field is enum string and type_default_group field is enum value.
        /// </summary>
        public enum UserTypeEnumFromID
        {
            SuperAdmin = 35,
            BLEmployeeLogin = 36,
            OSREmployeeLogin = 37,
            VendorLogin = 38
        }

        /// <summary>
        /// This value is mapping value of app_users_groups table. type_name_ntv field is enum string and app_users_groups field is enum value.
        /// </summary>
        public enum UserGroupEnum
        {
            Admin = 1,
            FPOC = 5,
            PolicyManager = 6,
            LM = 7,
            OSRUser = 8,
            Vendor = 10,
            HOD = 11,
            LM_FPOC = 12,
            LM_HOD = 13
        }

        /// <summary>
        /// Same enum at angular - enum-collection.ts
        ///user_action_type comment of app_users table, 1->Policy Manager, 2->FPOC, 3->HOD, 4->LM, 5->POC, 6->OSR, 7->Vendor Admin, 8->Vendor HR, 9-> Vendor Manager
        ///Spilt it by UserActionTypeVendorEnum 
        /// </summary>
        public enum UserActionTypeBLEnum
        {
            PolicyManager = 1,
            FPOC = 2,
            HOD = 3,
            LM = 4,
            POC = 5,
            OSR = 6,
            VendorAdmin = 20,
            VendorHR = 21,
            VendorManager = 22
        }

        /// <summary>
        /// Same enum at angular - enum-collection.ts
        ///user_action_type comment of app_users table, 1->Policy Manager, 2->FPOC, 3->HOD, 4->LM, 5->POC, 6->OSR, 7->Vendor Admin, 8->Vendor HR, 9-> Vendor Manager
        ///Full value - UserActionTypeBLEnum
        /// </summary>
        public enum UserActionTypeVendorEnum
        {
            Admin = 20,
            HR = 21,
            Manager = 22,
        }

        public enum UserStatusEnum
        {
            NewCreate = 1,
            Active = 2,
            Inactive = 3
        }

        /// <summary>
        /// It is master_cluster table cluster_type values. It is mention comment field like that '1=>B2C,2=>B2B,3=>,AC/MB,4=>Technology, 5=>General',
        /// </summary>
        public enum ClusterTypeEnum
        {
            B2C = 1,
            B2B = 2,
            AC = 3,
            Technology = 4,
            General = 5
        }



        
        

        /// <summary>
        /// Enum value for Osr Active/Inactive Status
        /// </summary>
        public enum OSRActiveStatus
        {
            Inactive = 0,
            Active = 1,
            Incomplete = 2,
            WithdrawalStep = 9,
            GooglePlayStoreUser = 100
        }

        /// <summary>
        /// Enum value for Vendor Active/Inactive Status
        /// </summary>
        public enum VendorActiveStatus
        {
            Inactive = 0,
            Active = 1
        }

        /// <summary>
        /// Enum value for Requisition Type
        /// </summary>
        public enum RequisitionType
        {
            HireRequisition = 1,
            Withdrawa = 2,
            Transfer = 3,
            Replacement = 4
        }

        /// <summary>
        /// This is master_assets_types table value of astype_id column. -- not used- 18 Dec 2023
        /// </summary>
        public enum MasterAssetCategoryEnum
        {
            ITAsset = 1,
            SoftwareAccess = 2
        }

        /// <summary>
        /// This is asset_category table value of id column.
        /// </summary>
        public enum AssetCategoryEnum
        {
            ITAsset = 1,
            SoftwareAsset = 2,
            AccessCard = 3
        }

        public enum RequisitionStatusEnum
        {
            Draft = 1,
            Submitted = 2,
            HODApproved = 3,
            FpocPoAttached = 4,
            PlaceToVendor = 5
        }

        /// <summary>
        /// The type is used in Document relation table where all types of documents are saved
        /// </summary>
        public enum DocumentReferenceTypeEnum
        {
            OSR = 1,
            JobDescription = 2,
            Agreement = 3,
            PO = 4 //Purchase Order
        }

        public enum MasterDocumentTypeEnum
        {
            EducationCertificateFile = 10,
            AppointmentLetterFile = 11,
            LastPayslipFile = 12,
            CoiLetterFile = 13,
            RelationshipDeclarationLetterFile = 14,
            CvFile = 15,
            NidFile = 16,
            CreditPaymentDeclarationFile = 17,
            NdaSignedCopyFile = 18,
            OfficeIdCardCopyFile = 19,
            AgencyEmploymentDeclarationLetterFile = 20,
            NomineeDeclarationLetterFile = 21,
            LastEmployerClearanceCertificateFile = 22
        }

        public enum MasterDocumentFileTypeEnum
        {
            pdf = 1
        }

        /// <summary>
        /// It is approval_reference_types table value. Any change here must to change database table.
        /// </summary>
        public enum ApprovalReferenceTypeEnum
        {
            JobDescription = 1,
            HiringRequisition = 2,
            TransferRequisition = 3,
            ReplacementReguisition = 4,
            WithdrawalRequisition = 5,
            LeaveApplication = 6,
            OvertimeRequiest = 7,
            ResignationApplication = 8,
            AttendanceUpdateApplication = 9
        }

        public enum TrueFalseEnum
        {
            FalseValue = 0,
            TrueValue = 1
        }

        /// <summary>
        /// It is reference value for master_functions table. And same defination have enum-collection file of ClientApp\src\app\common\static-string-data.
        /// </summary>
        public enum FunctionEnum
        {
            Enabler = 2,
            Commercial = 3,
            Technology = 4
        }

        /// <summary>
        /// It is reference value of comment of ofice_type column of master_office table. 1 => B2C, 2 => B2B, 3 => Generic/CE, 4=> Alternate channel/Monobrand
        /// </summary>
        public enum OfficeTypeEnum
        {
            B2C = 1,
            B2B = 2,
            GenericOrCE = 3,
            AC = 4
        }

        /// <summary>
        /// It is reference value of comment of sub_type column of master_office table. 1 => Retailer, 2 => CC-Code, 3 => Distributor, 4=> bl-office
        /// </summary>
        public enum OfficeSubTypeEnum
        {
            Retailer = 1,
            CC_Code = 2,
            Distributor = 3,
            BLOffice = 4
        }

        /// <summary>
        /// Job Description Status Enum
        /// </summary>
        public enum JobDescriptionStatusEnum
        {
            Draft = 1,
            Submitted = 2,
            Approved = 3,
            Revised = 4,
            Rejected = 10
        }

        /// <summary>
        /// PO Information Status Enum
        /// </summary>
        public enum POInformationStatusEnum
        {
            InActive = 0,
            Active = 1,
        }

        public enum SMSAPIUnicodeType
        {
            English = 0,
            Bangla = 1,
        }

        public enum LeaveApplicationStatus
        {
            OsrRequestedForLeave = 1,
            VendorSentToLm = 2,
            VendorRejected = 3,
            LmMarkedWithoutReplacement = 4,
            LmMarkedWithReplacement = 5,
            VendorApprovedAfterLmAction = 6,
            VendorRejectedAfterLmAction = 7,
            CancelledByApplicant = 8
        }

        public enum ResignationStatus
        {
            OsrSubmittedResignation = 1,
            VendorSentToLm = 2,
            VendorRejected = 3,
            LmMarkedWithoutReplacement = 4,
            LmMarkedWithReplacement = 5,
            VendorApprovedAfterLmAction = 6,
            VendorRejectedAfterLmAction = 7
        }

        public enum AttendanceUpdateApplicationStatus
        {
            RegularAppRequest = 0,
            UpdateRequest = 1,
            VendorSentToLmForReview = 2,
            VendorRejected = 3,
            LmMarkedReturn = 4,
            LmMarkedReviewed = 5,
            VendorRejectedAfterLMReviewed = 6,
            VendorApprovedAfterLMReviewed = 7
        }

        public enum DelegationStatusEnum
        {
            Pending = 1,
            Reject = 2,
            Accept = 3
        }

        public enum NotificationStatusEnum
        {
            Send = 0,
            Read = 1
        }

        public enum OsrReplacementStatus
        {
            Pending = 1,
            Partial = 2,
            Complete = 3
        }


        /// <summary>
        /// It is asset_transaction_type table value, It is master data.
        /// </summary>
        public enum AssetTransactionTypeEnum
        {
            AllocateToOsr = 1,
            DeAllocationFromOsr = 2,
            WriteOffOsr = 3
        }

        public enum OvertimeStatus
        {
            OvertimeRequestSubmitted = 1, //In Progress - In Osr View
            VendorSentToLm = 2, //In Progress - In Osr View
            VendorRejected = 3, //Rejected - In Osr View
            LmReviewed = 4, //In Progress - In Osr View
            LmReturned = 5, //Return - In Osr View
            VendorApprovedAfterLmReview = 6, //Approved - In Osr View
            VendorRejectedAfterLmReview = 7, //Rejected - In Osr View
            Resubmitted = 8 //In Progress - In osr View
        }

        public enum OvertimeDisbursementStatus
        {
            DisbursementRequested = 1,
            DisbursementRejected = 2
        }


        public enum SalaryComponentOperaTiontype
        {
            Payable = 1,
            Deductible = 2
        }
        public enum SalaryComponentTaxable
        {
            Taxable = 1,
            NonTaxable = 2
        }

        public enum SalaryComponentFixedAmount
        {
            FixedAmount = 1,
            VariableAmount = 2
        }
        public enum SalaryComponentIsBonus
        {
            NotBonusComponent = 1,
            BonusComponent = 2
        }
        public enum SalaryComponentIsSystemComponent
        {
            SystemDefinedComponent = 1,
            UserDefinedComponent = 2
        }

        public enum SalaryComponentIsPartOfGrossStatus
        {
            PartOfGross = 1,
            NotPartofGross = 2
        }

        public enum SalaryVendorGrossPackageStatus
        {
            Draft = 1,
            Submitted = 2,
        }

        public enum SalaryVendorComponentPackageStatus
        {
            Draft = 1,
            Submitted = 2,
        }

        public enum ExpenseClaimStatus
        {
            ExpenseClaimSubmitted = 1, //In Progress - In Osr View
            VendorSentToLm = 2, //In Progress - In Osr View
            VendorRejected = 3, //Rejected - In Osr View
            LmReviewed = 4, //In Progress - In Osr View
            LmReturned = 5, //Return - In Osr View
            VendorApprovedAfterLmReview = 6, //Approved - In Osr View
            VendorRejectedAfterLmReview = 7, //Rejected - In Osr View
            Resubmitted = 8 //In Progress - In osr View
        }


    }
}
