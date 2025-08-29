using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM:BaseLeaveTypeVM
    {
        //public int Id { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
