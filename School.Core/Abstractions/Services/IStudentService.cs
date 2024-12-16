using School.Core.CQRS.Student.Queries;

namespace School.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<GetStudentQuery> GetStudentAsync();
    }
}
