
using ImportArchivedDCNRCostaRequests.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests
{
    class Program
    {
        private readonly ICostaRepostitory costarepository;
        private readonly IOstRepository ostrepository;
        private readonly IMapper mapper;
        private readonly IAttachmentService attachmentservice;
        public Program(ICostaRepostitory costaRepository, IOstRepository ostRepository, IMapper Mapper, IAttachmentService attachmentService)
        {
            costarepository = costaRepository;
            ostrepository = ostRepository;
            mapper = Mapper;
            attachmentservice = attachmentService;
        }
        static void Main(string[] args)
        {
            var p = new Program(new CostaRepository(), new OstRepository(), new Mapper(), new AttachmentService()); 
            List<Workflow> costaWorkflows = p.costarepository.GetWorkflows();
            List<User> costaUsers = p.costarepository.GetUsers();
            List<Workflow> ostWorkflows = p.ostrepository.GetWorkflows();
            List<WorkflowVersion> ostWorkflowVersions = p.ostrepository.GetWorkflowVersions();
            List<WorkflowCategory> ostWorkflowCategories = p.ostrepository.GetWorkflowCategories();
            List<WorkflowDocument> ostWorkflowDocuments = p.ostrepository.GetWorkflowDocuments();
            List<WorkflowStep> ostWorkflowSteps = p.ostrepository.GetWorkflowSteps();
            List<Note> ostNotes = p.ostrepository.GetNotes();
            List<OstForm> ostOstForms = p.ostrepository.GetOstForms();
            List<COSTAForm> costaOstForms = p.mapper.MapOstForm(ostOstForms);

            //get rid of any workflows where the user id does not exist in costa.
            ostWorkflows = (from w in ostWorkflows
                            join f in ostOstForms on w.WorkflowId equals f.WorkflowId
                            join u in costaUsers on f.EmployeeUserId equals u.UserId
                            select w).ToList();

            // get rid of any ost workflows that are already in costa
            List<string> costaDocumentIds = costaWorkflows.Select(x => x.DocumentId).ToList();
            ostWorkflows = (from o in ostWorkflows
                            where !costaDocumentIds.Contains(o.DocumentId)
                            select o).ToList();

            Console.WriteLine($"{ostWorkflows.Count().ToString()} requests left to copy");

            foreach (var item in ostWorkflows.Take(10))
            {
                // insert workflow into costa
                int originalWorkflowid = item.WorkflowId;        
                int newWorkflowId = p.costarepository.InsertWorkflow(item);  

                //insert any workflow notes into costa
                var workflownotes = ostNotes.Where(x => x.NoteTypeId == (int)NoteTypes.Workflow && x.RecordId == originalWorkflowid);

                    foreach (var workflownote in workflownotes)
                    {
                        workflownote.RecordId = newWorkflowId;
                        int newNoteId = p.costarepository.InsertNote(workflownote);
                    }

                // insert any workflow documents into costa
                List<WorkflowDocument> workflowdocuments = ostWorkflowDocuments.Where(x => x.WorkflowId == originalWorkflowid).ToList();

                foreach (var workflowdocument in workflowdocuments)
                {
                    int originalWorkflowDocumentId = workflowdocument.WorkflowDocumentId;
                    workflowdocument.WorkflowId = newWorkflowId;
                    int newWorkflowDocumentId = p.costarepository.InsertWorkflowDocument(workflowdocument);
                }

                if (workflowdocuments.Count() > 0)
                {
                    p.attachmentservice.CopyAttachments(originalWorkflowid, newWorkflowId);
                }

                // insert the ostform into costa
                var form = costaOstForms.Where(x => x.WorkflowId == originalWorkflowid).FirstOrDefault();
                if (form != null)
                {
                    form.WorkflowId = newWorkflowId;
                    int newFormId = p.costarepository.InsertForm(form);
                }
                    // insert the workflowversions into costa
                    var workflowversions = ostWorkflowVersions.Where(x => x.WorkflowId == originalWorkflowid).ToList();
                    foreach (var workflowversion in workflowversions)
                    {
                    
                        int originalWorkflowVersionId = workflowversion.WorkflowVersionId;
                        int? originalCurrentStep = workflowversion.CurrentWorkflowStepId;

                        workflowversion.WorkflowId = newWorkflowId;
                        workflowversion.CurrentWorkflowStepId = null;

                        int newWorkflowVersionId = p.costarepository.InsertWorkflowVersion(workflowversion);

                        //insert the workflowversion notes into costa
                        var workflowversionnotes = ostNotes.Where(x => x.NoteTypeId == (int)NoteTypes.WorkflowVersion && x.RecordId == originalWorkflowVersionId);
                        foreach (var workflowversionnote in workflowversionnotes)
                        {
                            workflowversionnote.RecordId = newWorkflowVersionId;
                            int newNoteId = p.costarepository.InsertNote(workflowversionnote);
                        }

                        //insert the workfowcategories into costa
                        var workflowcategories = ostWorkflowCategories.Where(x => x.WorkflowVersionId == originalWorkflowVersionId).ToList();
                        foreach (var workflowcategory in workflowcategories)
                        {
                            int originalWorkflowCategoryId = workflowcategory.WorkflowCategoryId;

                            workflowcategory.WorkflowVersionId = newWorkflowVersionId;

                            int newWorkflowCategoryId = p.costarepository.InsertWorkflowCategory(workflowcategory);

                            //insert the workflowcategory notes into costa
                            var workflowcategorynotes = ostNotes.Where(x => x.NoteTypeId == (int)NoteTypes.WorkflowCategory && x.RecordId == originalWorkflowCategoryId);
                            foreach (var workflowcategorynote in workflowcategorynotes)
                            {
                                workflowcategorynote.RecordId = newWorkflowCategoryId;
                                int newNoteId = p.costarepository.InsertNote(workflowcategorynote);
                            }

                            //insert the workflowsteps into costa
                            var workflowsteps = ostWorkflowSteps.Where(x => x.WorkflowCategoryId == originalWorkflowCategoryId).ToList();

                            foreach (var step in workflowsteps)
                            {
                                int originalWorkflowStepId = step.WorkflowStepId;
                                step.WorkflowCategoryId = newWorkflowCategoryId;
                                int newWorkflowStepId = p.costarepository.InsertWorkflowStep(step);

                                // if the workflowversion from ost had a current workflow step add it into costa
                                if (originalCurrentStep != null && originalCurrentStep.Value == originalWorkflowStepId)
                                {
                                    workflowversion.CurrentWorkflowStepId = newWorkflowStepId;
                                    p.costarepository.UpdateWorkflowVersion(workflowversion.WorkflowVersionId, newWorkflowStepId);
                                }
                                // add the workflow step notes into costa
                                var workflowStepNotes = ostNotes.Where(x => x.NoteTypeId == (int)NoteTypes.WorkflowStep && x.RecordId == originalWorkflowStepId).ToList();
                                foreach (var workflowstepnote in workflowStepNotes)
                                {
                                    workflowstepnote.RecordId = newWorkflowStepId;
                                    int newNoteId = p.costarepository.InsertNote(workflowstepnote);
                                }
                            }
                        }
                    }
            
                Console.WriteLine($"copied {item.DocumentId}");
            }

            Console.WriteLine("complete");
            Console.ReadLine();

        }

      
    }
}
