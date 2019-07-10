using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public interface IAttachmentService
    {
        void CopyAttachments(int originalWorkflowid, int newWorkflowId);
    }
}
