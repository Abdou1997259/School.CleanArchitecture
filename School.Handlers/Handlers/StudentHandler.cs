using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Abstractions.Services;
using School.Core.Bases;
using School.Core.CQRS.Students.Commands;
using School.Core.CQRS.Students.Queries;
using School.Core.Dtos.Responses.StudentReponse;
using School.Core.Dtos.Responses.StudentResponse;
using School.Core.Resources;
using School.Data.Constants.AppMetaData;
using School.Data.Entities;
namespace School.Handlers.Handlers
{
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetStudentQueryBydId, Response<GetStudentResponse>>,
        IRequestHandler<AddStudentCommand, Response<Student>>,
        IRequestHandler<GetPaginationStudentSpecification, Response<PaginationResult<StudentPaginationResponse>>>
    {
        #region contsructor
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        public async Task<Response<GetStudentResponse>> Handle(GetStudentQueryBydId request, CancellationToken cancellationToken)
        {
            var result = await _studentService.GetStudentByIdAsync(request.Id);
            if (result == null)
                return NotFound<GetStudentResponse>(_stringLocalizer[Localization.NotFound, _stringLocalizer[Localization.Student]]);
            return Success(result);
        }

        public async Task<Response<Student>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedObj = _mapper.Map<Student>(request);
            return Created(await _studentService.AddStudent(mappedObj));
        }

        public async Task<Response<PaginationResult<StudentPaginationResponse>>> Handle(GetPaginationStudentSpecification request, CancellationToken cancellationToken)
        {
            var result = await _studentService.GetAllPaginatedStudents(request);

            if (result.Data == null || result.Data.Count() == 0)
                return NotFound<PaginationResult<StudentPaginationResponse>>(_stringLocalizer[Localization.EmptyData]);


            return Success(result);
        }
    }
}
