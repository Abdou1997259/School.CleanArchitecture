using School.Core.Bases;
using School.Core.Dtos.Requests.StudentRequest;
using School.Core.Dtos.Responses.StudentReponse;
using School.Core.Dtos.Responses.StudentResponse;
using School.Data.Entities;

namespace School.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(Student student);
        Task<GetStudentResponse> GetStudentByIdAsync(int id);
        Task<bool> IsNameExistAsync(string name);
        Task<PaginationResult<StudentPaginationResponse>> GetAllPaginatedStudents(StudentPaginationRequest model);

    }
}
