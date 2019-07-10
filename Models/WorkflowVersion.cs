using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests.Models
{
    [Table("Portal.WorkflowVersions")]
    public class WorkflowVersion
    {

        public int WorkflowVersionId { get; set; }

        public int WorkflowVersionTypeId { get; set; }

        public int WorkflowId { get; set; }

        public int? WorkflowSponsorId { get; set; }

        public int? CurrentWorkflowSponsorContactId { get; set; }

        public string VersionId { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? RenewalExpirationDate { get; set; }

        public int? PercentComplete { get; set; }

        public int? CurrentWorkflowStepId { get; set; }

        public bool IsValid { get; set; }

        public int Order { get; set; }
    }
}