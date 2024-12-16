using MediatR;
using School.Core.Bases;
using School.Core.Dtos.Responses.StudentReponse;


namespace School.Core.CQRS.Student.Queries
{
    public class GetStudentQuery : IRequest<Response<List<GetStudentResponse>>>
    {
    }
}
