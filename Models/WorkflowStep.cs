using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests
{
    [Table("Portal.WorkflowSteps")]
    public class WorkflowStep
    {
        public int WorkflowStepId { get; set; }

        public int WorkflowStepTypeId { get; set; }

        public int WorkflowStatusTypeId { get; set; }

        public int WorkflowCategoryId { get; set; }

        public int Order { get; set; }

        public DateTime? DueByDate { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? ReviewedDate { get; set; }

        public int? ReviewedBy { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int? CompletedBy { get; set; }
    }
}