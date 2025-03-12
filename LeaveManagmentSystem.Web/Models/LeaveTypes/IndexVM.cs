namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class IndexVM // renamed to LeaveTypeReadOnlyVM as its common in few views like Indiex and Details
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }

    }
}
