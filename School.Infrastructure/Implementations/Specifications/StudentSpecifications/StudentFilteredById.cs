using School.Core.Bases;
using School.Core.Dtos.Responses.StudentReponse;
using School.Data.Entities;

namespace School.Infrastructure.Implementations.Specifications.StudentSpecifications
{
    public class StudentFilteredById : ISpecification<Student, GetStudentResponse>
    {
        public StudentFilteredById(int id, GetStudentResponse select) : base(x => x.Id == id)
        {
            AddInclude(x => x.Department);
            AddSelector(x => new GetStudentResponse
            {
                Name = x.GetName(),
                Address = x.Address,
                DepartmentName = x.Department.GetName(),
                Phone = x.Phone,
            });

        }
    }
}
