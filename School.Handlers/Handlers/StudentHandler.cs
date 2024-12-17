using AutoMapper;
using MediatR;
using School.Core.Abstractions.Services;
using School.Core.Bases;
using School.Core.CQRS.Students.Commands;
using School.Core.CQRS.Students.Queries;
using School.Core.Dtos.Responses.StudentReponse;
using School.Data.Entities;

namespace School.Handlers.Handlers
{
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetStudentQueryBydId, Response<GetStudentResponse>>,
        IRequestHandler<AddStudentCommand, Response<Student>>
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
        public async Task<Response<GetStudentResponse>> Handle(GetStudentQueryBydId request, CancellationToken cancellationToken)
        {
            var result = await _studentService.GetStudentByIdAsync(request.Id);
            return Success(result);
        }

        public async Task<Response<Student>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedObj = _mapper.Map<Student>(request);
            return Created(await _studentService.AddStudent(mappedObj));
        }
    }
}
