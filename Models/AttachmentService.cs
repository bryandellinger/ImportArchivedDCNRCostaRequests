using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public class AttachmentService : IAttachmentService
    {
        private readonly string ostBasePath;
        private readonly string copiedAttachmentsBasePath;
        public AttachmentService()
        {
            ostBasePath = ConfigurationManager.AppSettings["OstBasePath"];
            copiedAttachmentsBasePath = ConfigurationManager.AppSettings["CopiedAttachmentsBasePath"];
        }
        public void CopyAttachments(int originalWorkflowid, int newWorkflowId)
        {
            string folderToCopy = $"{this.ostBasePath}{originalWorkflowid}";
            string newFolder = $"{this.copiedAttachmentsBasePath}{newWorkflowId}";
            Directory.CreateDirectory(newFolder);
            DirectoryInfo dir = new DirectoryInfo(folderToCopy);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(newFolder, file.Name);
                file.CopyTo(temppath, false);
            }
        }
    }
}
