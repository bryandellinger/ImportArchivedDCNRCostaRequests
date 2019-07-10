using System.ComponentModel.DataAnnotations.Schema;

namespace ImportArchivedDCNRCostaRequests
{
    [Table("Portal.Users")]
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int PositionTypeId { get; set; }
        public int? RoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SignatureName { get; set; }
        public string SignatureTitle { get; set; }
        public string PositionNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string Bureau { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string PositionDescription { get; set; }

        public bool AccessAllLocationsInd { get; set; }

        public int? AssignedLocationId { get; set; }

        public int? PresetId { get; set; }

        public int? ThemeId { get; set; }

        public bool HideWidgetSideListInd { get; set; }
        public bool? OverrideSyncInd { get; set; }
        public bool ActiveInd { get; set; }
    }
}