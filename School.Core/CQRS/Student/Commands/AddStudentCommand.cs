using MediatR;
using School.Core.Bases;
using School.Data.Entities;

namespace School.Core.CQRS.Students.Commands
{
    public class AddStudentCommand : IRequest<Response<Student>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }

        public int? DID { get; set; }
    }
}
