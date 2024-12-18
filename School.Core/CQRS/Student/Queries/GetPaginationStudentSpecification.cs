using MediatR;
using School.Core.Bases;
using School.Core.Dtos.Requests.StudentRequest;
using School.Core.Dtos.Responses.StudentResponse;

namespace School.Core.CQRS.Students.Queries
{
    public class GetPaginationStudentSpecification : StudentPaginationRequest, IRequest<Response<PaginationResult<StudentPaginationResponse>>>
    {
    }
}
