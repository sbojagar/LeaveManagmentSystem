using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
namespace LeaveManagmentSystem.Web.MappingProfile
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            // .ForMember(dest =>dest.Days,opt=> opt.MapFrom(src => src.NumberOfDays));  //Incase the ViewModel has Days property name instead of NumberofDays.Has performance cost

            CreateMap<LeaveTypeCreateVM, LeaveType>();
               
        }
    }
}
