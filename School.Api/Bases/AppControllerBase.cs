
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Bases;
namespace School.Api.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _senderInstance;
        protected IMediator Sender => _senderInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case System.Net.HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case System.Net.HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case System.Net.HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case System.Net.HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);


            };
        }

    }
}
