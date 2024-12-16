using School.Core.Abstractions.Repositories;
using School.Core.Dtos.Responses.StudentReponse;

namespace School.Infrastructure.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {

        }
        public async Task<List<GetStudentResponse>> GetStudentListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
