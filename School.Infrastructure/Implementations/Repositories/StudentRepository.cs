using School.Core.Abstractions.Repositories;
using School.Core.Dtos.Requests.StudentRequest;

namespace School.Infrastructure.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {

        }
        public async Task<List<GetStudentRequest>> GetStudentListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
