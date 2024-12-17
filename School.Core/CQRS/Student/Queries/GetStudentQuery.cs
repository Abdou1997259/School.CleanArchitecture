using MediatR;
using School.Core.Bases;
using School.Core.Dtos.Responses.StudentReponse;


namespace School.Core.CQRS.Students.Queries
{
    public class GetStudentQueryBydId : IRequest<Response<GetStudentResponse>>
    {
        public GetStudentQueryBydId(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
    }
}
