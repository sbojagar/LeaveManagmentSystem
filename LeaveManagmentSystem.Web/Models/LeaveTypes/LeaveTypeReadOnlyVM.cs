using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LeaveTypeName { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }
    }
}
