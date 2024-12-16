using School.Core.Dtos.Responses.StudentReponse;

namespace School.Core.Abstractions.Repositories
{
    public interface IStudentRepository
    {
        Task<List<GetStudentResponse>> GetStudentListAsync();
    }
}
