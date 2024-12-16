using School.Core.Abstractions.Repositories;
using School.Core.Abstractions.Services;
using School.Core.CQRS.Student.Queries;

namespace School.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }
        public async Task<GetStudentQuery> GetStudentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
