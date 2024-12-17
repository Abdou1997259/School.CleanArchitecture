using School.Core.Bases;
using School.Data.Entities;

namespace School.Infrastructure.Implementations.Specifications.StudentSpecifications
{
    public class GetStudentByNameSpecification : ISpecification<Student, string>
    {
        public GetStudentByNameSpecification(string name) : base(x => x.NameAr == name || x.NameEn == name)
        {
            AddSelector(x => x.GetName());
        }

    }
}
