using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests.Models
{
    [Table("Portal.Notes")]
    public class Note
    {
        public int NoteId { get; set; }

        public int NoteTypeId { get; set; }

        public int RecordId { get; set; }

        public bool SystemGeneratedInd { get; set; }
        public string NoteText { get; set; }
    }
}