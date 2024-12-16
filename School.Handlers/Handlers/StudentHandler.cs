using AutoMapper;
using MediatR;
using School.Core.Abstractions.Services;
using School.Core.Bases;
using School.Core.CQRS.Student.Queries;
using School.Core.Dtos.Responses.StudentReponse;

namespace School.Handlers.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentQuery, Response<List<GetStudentResponse>>>
    {
        #region contsructor
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetStudentResponse>>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return Success()
        }
    }
}
