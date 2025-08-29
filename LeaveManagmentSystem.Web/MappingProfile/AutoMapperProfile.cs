using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
namespace LeaveManagmentSystem.Web.MappingProfile
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
                .ForMember(dest => dest.Name, opt=> opt.MapFrom(src=> src.LeaveTypeName));
            // .ForMember(dest =>dest.Days,opt=> opt.MapFrom(src => src.NumberOfDays));  //Incase the ViewModel has Days property name instead of NumberofDays.Has performance cost

            CreateMap<LeaveTypeCreateVM, LeaveType>()
                .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.Name));

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap()
                .ForMember(dest => dest.Name, opt=> opt.MapFrom(src=> src.LeaveTypeName));

        }
    }

    //public class MyMappingProfile : Profile
    //{
    //    public MyMappingProfile()
    //    {
    //        CreateMap<SourceEntity, DestinationEntity>()
    //            .ForMember(dest => dest.CSharpPropertyName, opt => opt.MapFrom(src => src.DbColumnName));
    //    }
    //}
}
