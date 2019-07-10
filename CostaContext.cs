using ImportArchivedDCNRCostaRequests.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArchivedDCNRCostaRequests
{
    public class CostaContext : DbContext
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultCostaConnection"].ConnectionString;
        public CostaContext()
            : base("name=DefaultCostaConnection")
        {
            Database.SetInitializer<CostaContext>(null);
        }

        public virtual DbSet<COSTAForm> OSTForms { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<WorkflowVersion> WorkflowVersions { get; set; }
        public virtual DbSet<WorkflowCategory> WorkflowCategories { get; set; }
        public virtual DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkflowDocument> WorkflowDocuments { get; set; }

    }
}
