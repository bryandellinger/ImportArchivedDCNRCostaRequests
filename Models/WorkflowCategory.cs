using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests.Models
{
    [Table("Portal.WorkflowCategories")]
    public class WorkflowCategory
    {
        public int WorkflowCategoryId { get; set; }

        public int WorkflowVersionId { get; set; }

        public int WorkflowCategoryTypeId { get; set; }

        public int WorkflowStatusTypeId { get; set; }

        public int WorkflowTypeId { get; set; }

        public bool ActiveInd { get; set; }

        public int Order { get; set; }
    }
}