using Microsoft.AspNetCore.Http;
using School.Core.Bases;
using System.Net;

namespace School.Handlers.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string> { Succeeded = false, Message = "" };
                switch (ex)
                {
                    case FluentValidation.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableContent;
                        responseModel.Errors = (List<string>)e.Errors;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = "Internal server error";
                        break;

                }
                await response.WriteAsync(responseModel.ToString());
            }

        }
    }
}
