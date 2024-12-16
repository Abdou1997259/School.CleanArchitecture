
using School.Core.Dtos.Requests.StudentRequest;

namespace School.Core.Abstractions.Repositories
{
    public interface IStudentRepository
    {
        Task<List<GetStudentRequest>> GetStudentListAsync();
    }
}
