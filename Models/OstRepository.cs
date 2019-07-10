using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public class OstRepository : IOstRepository
    {
        public List<OstForm> GetOstForms()
        {
            {
                {
                    using (var context = new OstContext())
                    {
                        List<OstForm> ostForms = context.OSTForms.Where(x => x.EmployeeUserId != null).ToList();
                        return ostForms;
                    }
                }
            }
        }

        public List<Workflow> GetWorkflows()
        {
            using (var context = new OstContext())
            {
                List<Workflow> workflows = (from f in context.OSTForms.Where(x => x.EmployeeUserId != null)
                                            join w in context.Workflows.Where(x => x.StatusDescription == "Approved") on f.WorkflowId equals w.WorkflowId
                                            select w).ToList();
                return workflows;
            }
        }

        public List<WorkflowVersion> GetWorkflowVersions()
        {
            using (var context = new OstContext())
            {
                List<WorkflowVersion> workflowversions = (from f in context.OSTForms.Where(x => x.EmployeeUserId != null)
                                                          join w in context.Workflows.Where(x => x.StatusDescription == "Approved") on f.WorkflowId equals w.WorkflowId
                                                          join wv in context.WorkflowVersions on w.WorkflowId equals wv.WorkflowId
                                            select wv).ToList();
                return workflowversions;
            }
        }

        public List<WorkflowCategory> GetWorkflowCategories()
        {
            using (var context = new OstContext())
            {
                List<WorkflowCategory> workflowcategories = (from f in context.OSTForms.Where(x => x.EmployeeUserId != null)
                                                             join w in context.Workflows.Where(x => x.StatusDescription == "Approved") on f.WorkflowId equals w.WorkflowId
                                                             join wv in context.WorkflowVersions on w.WorkflowId equals wv.WorkflowId
                                                          join wc in context.WorkflowCategories on wv.WorkflowVersionId equals wc.WorkflowVersionId
                                                          select wc).ToList();
                return workflowcategories;
            }
        }

        public List<WorkflowStep> GetWorkflowSteps()
        {
            using (var context = new OstContext())
            {
                List<WorkflowStep> workflowsteps = (from f in context.OSTForms.Where(x => x.EmployeeUserId != null)
                                                    join w in context.Workflows.Where(x => x.StatusDescription == "Approved") on f.WorkflowId equals w.WorkflowId
                                                    join wv in context.WorkflowVersions on w.WorkflowId equals wv.WorkflowId
                                                             join wc in context.WorkflowCategories on wv.WorkflowVersionId equals wc.WorkflowVersionId
                                                             join ws in context.WorkflowSteps on wc.WorkflowCategoryId equals ws.WorkflowCategoryId
                                                             select ws).ToList();
                return workflowsteps;
            }
        }

        public List<Note> GetNotes()
        {
            using (var context = new OstContext())
            {
                return context.Notes.ToList();
            }
        }

        public List<WorkflowDocument> GetWorkflowDocuments()
        {
            using (var context = new OstContext())
            {
                List<WorkflowDocument> workflowdocuments = (from f in context.OSTForms.Where(x => x.EmployeeUserId != null)
                                                            join w in context.Workflows.Where(x => x.StatusDescription == "Approved") on f.WorkflowId equals w.WorkflowId
                                                            join wd in context.WorkflowDocuments on w.WorkflowId equals wd.WorkflowId
                                                          select wd).ToList();
                return workflowdocuments;
            }
        }
    }
}
