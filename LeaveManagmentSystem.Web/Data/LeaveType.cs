using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Web.Data
{
    public class LeaveType
    {
        [Key] 
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string LeaveTypeName { get; set; }
        public int NumberOfDays { get; set; }
    }
}
