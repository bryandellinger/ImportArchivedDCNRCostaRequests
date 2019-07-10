using System.Configuration;
using System.Data.Entity;

namespace ImportArchivedDCNRCostaRequests.Models
{
    public class OstContext : DbContext
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultOstConnection"].ConnectionString;

        public OstContext()
            : base("name=DefaultOstConnection")
        {
            Database.SetInitializer<OstContext>(null);
        }

        public virtual DbSet<OstForm> OSTForms { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<WorkflowVersion> WorkflowVersions { get; set; }
        public virtual DbSet<WorkflowCategory> WorkflowCategories { get; set; }
        public virtual DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<WorkflowDocument> WorkflowDocuments { get; set; }
    }
}
