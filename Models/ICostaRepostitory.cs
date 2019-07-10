using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
   public  interface ICostaRepostitory
    {
        List<Workflow> GetWorkflows();
        List<User> GetUsers();
        int InsertWorkflow(Workflow item);
        int InsertForm(COSTAForm form);
        int InsertWorkflowVersion(WorkflowVersion workflowversion);
        int InsertWorkflowCategory(WorkflowCategory workflowcategory);
        int InsertWorkflowStep(WorkflowStep step);
        void UpdateWorkflowVersion(int workflowVersionId, int newWorkflowStepId);
        int InsertNote(Note workflowstepnote);
        int InsertWorkflowDocument(WorkflowDocument workflowdocument);
    }
}
