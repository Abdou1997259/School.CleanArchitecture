using School.Core.Abstractions.Repositories;
using School.Data.Entities;
using School.Infrastructure.Bases;
using School.Infrastructure.Context;

namespace School.Infrastructure.Implementations.Repositories.StudentRepositories
{
    public class StudentRepository(ApplicationDBContext db) : GenericRepository<Student>(db), IStudentRepository
    {


    }
}
