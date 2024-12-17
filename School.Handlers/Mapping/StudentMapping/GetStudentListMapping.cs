using School.Core.Dtos.Responses.StudentReponse;
using School.Data.Entities;

namespace School.Handlers.Mapping.StudentProfiles
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentResponse>()
                .ForMember(x => x.DepartmentName, p => p.MapFrom(x => x.Department.GetName()));
        }
    }
}
