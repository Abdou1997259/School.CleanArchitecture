using MediatR;
using School.Core.Abstractions.Services;
using School.Core.CQRS.Student.Queries;

namespace School.Handlers.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentQuery, List<GetStudentQuery>>
    {
        #region contsructor
        private readonly IStudentService _studentService;
        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion
        public async Task<List<GetStudentQuery>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
