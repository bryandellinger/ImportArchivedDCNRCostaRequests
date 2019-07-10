using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    [Table("HR.OSTForms")]
    public class OstForm {

   public int OSTFormId { get; set; }

    public int? WorkflowId { get; set; }

    public bool? IsTraining { get; set; }

    public bool? IsOSTforOthersInd { get; set; }

    public int? PreparerUserId { get; set; }

    public string PreparerName { get; set; }

    public string PreparerPosition { get; set; }

    public string PreparerPhone { get; set; }

    public string PreparerEmail { get; set; }

    public int? EmployeeUserId { get; set; }

    public string EmployeeFirstName { get; set; }

    public string EmployeeMiddleName { get; set; }

    public string EmployeeLastName { get; set; }

    public string EmployeeNumber { get; set; }

    public string EmployeeEmail { get; set; }

    public string EmployeeBureau { get; set; }

    public string EmployeeWorkAddress { get; set; }

    public string EmployeeWorkPhone { get; set; }

    public string EmployeePosition { get; set; }

    public string EmployeeAgency { get; set; }

    public int? EmployeeSupervisorUserId { get; set; }

    public bool? EmployeeSupervisorManuallySelectedInd { get; set; }

    public int? EmployeeManagerUserId { get; set; }

    public bool? EmployeeManagerManuallySelectedInd { get; set; }

    public string CourseTitle { get; set; }

    public string CourseDescription { get; set; }

    public string CourseObjectives { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? RegistrationDeadline { get; set; }

    public decimal? OSTHours { get; set; }

    public bool? IsDevelopmentOpportunityInd { get; set; }

    public bool? IsRequiredForPositionInd { get; set; }

    public string RequiredForPositionDescription { get; set; }

    public bool? IsAcademicInd { get; set; }

    public bool? IsComputerTrainingInd { get; set; }

    public bool? IsProfessionalLicensureInd { get; set; }

    public bool? IsLicensureTestingInd { get; set; }

    public decimal? TotalAcademicCredits { get; set; }

    public int? OSTEventTypeId { get; set; }

    public string OtherEventDescription { get; set; }

    public bool? IsDiscountAvailableInd { get; set; }

    public int? OSTDiscountTypeId { get; set; }

    public string DiscountAssociationName { get; set; }

    public string DiscountOtherDescription { get; set; }

    public DateTime? DiscountDeadline { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string TrainingSourceName { get; set; }

    public string TrainingCity { get; set; }

    public string TrainingZip { get; set; }

    public int? TrainingStateId { get; set; }

    public string DepartingCity { get; set; }

    public int? DepartingStateId { get; set; }

    public string TrainingWebsite { get; set; }

    public bool? IsTrainingMissionCritical { get; set; }

    public string MissionCriticalDescription { get; set; }

    public string TrainingPurposeDescription { get; set; }

    public bool? IsTravelRequired { get; set; }

    public DateTime? TravelStartDate { get; set; }

    public DateTime? TravelEndDate { get; set; }

    public string TravelPurposeDescription { get; set; }

    public string TravelRequirementsDescription { get; set; }

    public string EventBenefitsDescription { get; set; }

    public string OtherPurposeDescription { get; set; }

    public int? OSTTransportationModeTypeId { get; set; }

    public int? EstimateMileage { get; set; }

    public bool? IsInDrivingDistance { get; set; }

    public string DrivingDistanceDescription { get; set; }

    public bool? IsReimbursement { get; set; }

    public bool? IsCarPool { get; set; }

    public bool? IsPersonalCarReimbursement { get; set; }

    public bool? IsDriver { get; set; }

    public bool? IsGiftBanFitInd { get; set; }

    public string CarPoolGroup { get; set; }

    public string OtherTransportationModeDescription { get; set; }

    public decimal? TrainingFeeAmount { get; set; }

    public decimal? LodgingAmount { get; set; }

    public bool? IsLodgingCostEfficient { get; set; }

    public string LodgingCostDescription { get; set; }

    public decimal? SubsistenceAmount { get; set; }

    public bool? IsMealReimbursement { get; set; }

    public decimal? TransportationAmount { get; set; }

    public decimal? OtherCostsAmount { get; set; }

    public string OtherCostsDescription { get; set; }

    public decimal? RegistrationAmount { get; set; }

    public decimal? OtherFundsAmount { get; set; }

    public bool? IsCommonwealthFundsInd { get; set; }

    public string CommonwealthFundName { get; set; }

    public bool? IsFederalFundsInd { get; set; }

    public bool? IsProfessionalAssociationFundsInd { get; set; }

    public bool? IsThirdPartyVendorFundsInd { get; set; }

    public bool? IsOtherFundsInd { get; set; }

    public string OtherFundingDescription { get; set; }

    public bool? IsAssociationCoverTravel { get; set; }

    public string AssociationDuesDescription { get; set; }

    public string CommonwealthVendorsDescription { get; set; }

    public string TravelFundsAllocationDescription { get; set; }

    public decimal? TotalTrainingCostsAmount { get; set; }

    public decimal? TotalDCNRFundsAmount { get; set; }

    public decimal? TotalFedFundsAmount { get; set; }

    public string FedGrantName { get; set; }

    public bool? IsFedFundsForOtherUseInd { get; set; }

    public decimal? TotalThirdPartyFundsAmount { get; set; }

    public string ThirdPartyName { get; set; }

    public string ThirdPartyFundsSource { get; set; }

    public bool? IsThirdPartyOversee { get; set; }

    public decimal? TotalProfessionalFundsAmount { get; set; }

    public string ProfessionalFundsName { get; set; }

    public decimal? TotalPaidAmount { get; set; }

    public string MeetingEventInitiatedBy { get; set; }

    public string MeetingEventInitiatorDescription { get; set; }

    public string MetricsForSuccessDescription { get; set; }

    public string SpecialIssuesOrConcernsDescription { get; set; }

    public DateTime? DateAuthorizationNeeded { get; set; }

    public string AuthorizationNo { get; set; }

    public bool? IsOutOfStateInd { get; set; }

    public bool? IsOutOfCountryInd { get; set; }

    public bool? IsLockedForSubmitterInd { get; set; }

    public string GeneralComment { get; set; }

    public string CancelComment { get; set; }

    public string InternationalAddress { get; set; }

    public string ImportName { get; set; }

    public DateTime? ApprovalRequestedByDate { get; set; }
}
}
