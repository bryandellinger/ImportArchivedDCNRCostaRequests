using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public class CostaRepository : ICostaRepostitory
    {
        public List<User> GetUsers()
        {
            using (var context = new CostaContext())
            {
                return context.Users.ToList();
            }
        }

        public List<Workflow> GetWorkflows()
        {
            {
                using (var context = new CostaContext())
                {
                    List<Workflow> workflows = (from f in context.OSTForms.Where(x => x.DepartmentTypeId == 1)
                                               join w in context.Workflows on f.WorkflowId equals w.WorkflowId
                                               select w).ToList();
                    return workflows;
                }
            }
        }

        public int InsertWorkflow(Workflow item)
        {
            using (var context = new CostaContext())
            {
                context.Workflows.Add(item);
                context.SaveChanges();
                return item.WorkflowId;
            }
        }

        public int InsertForm(COSTAForm item)
        {
            using (var context = new CostaContext())
            {
                context.OSTForms.Add(item);
                context.SaveChanges();
                return item.OSTFormId;
            }
        }


        public int InsertWorkflowVersion(WorkflowVersion item)
        {
            using (var context = new CostaContext())
            {
                context.WorkflowVersions.Add(item);
                context.SaveChanges();
                return item.WorkflowVersionId;
            }
        }

        public int InsertWorkflowCategory(WorkflowCategory workflowcategory)
        {
            using (var context = new CostaContext())
            {
                context.WorkflowCategories.Add(workflowcategory);
                context.SaveChanges();
                return workflowcategory.WorkflowCategoryId;
            }
        }

        public int InsertWorkflowStep(WorkflowStep step)
        {
            using (var context = new CostaContext())
            {
                context.WorkflowSteps.Add(step);
                context.SaveChanges();
                return step.WorkflowStepId;
            }
        }

        public void UpdateWorkflowVersion(int workflowVersionId, int newWorkflowStepId)
        {
            using (var context = new CostaContext())
            {
                var std = context.WorkflowVersions.First(x => x.WorkflowVersionId == workflowVersionId);
                std.CurrentWorkflowStepId = newWorkflowStepId;
                context.SaveChanges();
            }
        }

        public int InsertNote(Note note)
        {
            using (var context = new CostaContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
                return note.NoteId;
            }
        }

        public int InsertWorkflowDocument(WorkflowDocument workflowdocument)
        {
            using (var context = new CostaContext())
            {
                context.WorkflowDocuments.Add(workflowdocument);
                context.SaveChanges();
                return workflowdocument.WorkflowDocumentId;
            }
        }
    }
}
