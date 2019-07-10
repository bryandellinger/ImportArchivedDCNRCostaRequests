using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests.Models
{
    [Table("Portal.WorkflowDocuments")]
    public class WorkflowDocument
    {
        public int WorkflowDocumentId { get; set; }

        public int WorkflowDocumentTypeId { get; set; }

        public int WorkflowId { get; set; }

        public int? WorkflowVersionId { get; set; }

        public int? WorkflowCategoryId { get; set; }

        public int? WorkflowStepId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string ContentType { get; set; }

        public DateTime? DocumentDate { get; set; }

        public string NoteText { get; set; }
    }
}