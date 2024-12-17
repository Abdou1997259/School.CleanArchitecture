using Microsoft.EntityFrameworkCore;
using School.Core.Abstractions.Services;
using School.Core.Bases;
using School.Core.Dtos.Responses.StudentReponse;
using School.Data.Entities;
using School.Infrastructure.Implementations.Specifications.StudentSpecifications;

namespace School.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<Student> DeleteStudent(Student student)
        {
            var result = _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<GetStudentResponse> GetStudentByIdAsync(int id)
        {
            var spec = new StudentFilteredById(id, new GetStudentResponse()); // Ensure this specification is correct and not null
            var resultQuery = _unitOfWork.StudentRepository.ApplySpecification<GetStudentResponse>(spec);

            if (resultQuery == null)
                throw new InvalidOperationException("No query returned for the given specification.");

            var res = await resultQuery.ToListAsync();

            if (res == null || !res.Any())
                return null; // Or throw an exception if no result is found

            return res.First(); // Assuming only one result is expected
        }

        public async Task<bool> IsNameExistAsync(string name)
        {
            var spec = new GetStudentByNameSpecification(name);
            var result = await _unitOfWork.StudentRepository.ApplySpecification(spec).FirstOrDefaultAsync();
            return result != null;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
