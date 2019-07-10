using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests
{
    [Table("Portal.Workflows")]
    public class Workflow
    {
        public int WorkflowId { get; set; }

        public int? ParentWorkflowId { get; set; }

        public string DocumentId { get; set; }

        public int? PrimaryLocationId { get; set; }

        public int WorkflowTypeId { get; set; }

        public int? EventTypeId { get; set; }

        public int WorkflowRecordStatusTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LocationDescription { get; set; }

        public string StatusDescription { get; set; }
 
    }
}
