using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [Length(4,50,ErrorMessage = "Length should be 4-50 characters.")]
        public string LeaveTypeName { get; set; } = string.Empty;

        [Required]
        [Range(1,100,ErrorMessage ="Range not Valid.")]
        public int NumberOfDays { get; set; }
    }
}
