using AutoMapper;

namespace School.Handlers.Mapping.StudentProfiles
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();

        }
    }
}
