using MediatR;

namespace School.Core.CQRS.Student.Queries
{
    public class GetStudentQuery : IRequest<List<GetStudentQuery>>
    {
    }
}
