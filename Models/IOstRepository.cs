using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public interface IOstRepository
    {
        List<OstForm> GetOstForms();
        List<Workflow> GetWorkflows();
        List<WorkflowVersion> GetWorkflowVersions();
        List<WorkflowCategory> GetWorkflowCategories();
        List<WorkflowStep> GetWorkflowSteps();
        List<Note> GetNotes();
        List<WorkflowDocument> GetWorkflowDocuments();
    }
}
