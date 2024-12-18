using Microsoft.AspNetCore.Mvc;
using School.Api.Bases;
using School.Core.CQRS.Students.Commands;
using School.Core.CQRS.Students.Queries;
using School.Data.Constants.AppMetaData;

namespace School.Api.Controllers
{

    [ApiController]
    public class StudentController : AppControllerBase
    {
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] AddStudentCommand Student)
        {
            var result = await Sender.Send(Student);
            return NewResult(result);
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await Sender.Send(new GetStudentQueryBydId(id));
            return NewResult(result);
        }
        [HttpGet(Router.StudentRouting.GetPaginationStudent)]
        public async Task<IActionResult> GetPaginationStudent([FromQuery] GetPaginationStudentSpecification model)
        {
            var result = await Sender.Send(model);
            return NewResult(result);
        }
    }
}
