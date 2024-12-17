using School.Core.CQRS.Students.Commands;
using School.Data.Entities;

namespace School.Handlers.Mapping.StudentProfiles
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>();
        }
    }
}
