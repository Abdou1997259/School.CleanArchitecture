using Microsoft.Extensions.Localization;
using School.Core.Resources;
using School.Data.Constants.AppMetaData;
using System.Net;

namespace School.Core.Bases
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public ResponseHandler(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;

        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[Localization.Deleted]

            };
        }
        public Response<T> Success<T>(T entity, object meta = null)
        {
            return new Response<T>
            {
                Date = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = Localization.Success,
                Meta = meta

            };

        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = Localization.UnUnauthorized
            };
        }
        public Response<T> BadRequest<T>(string message)
        {

            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[Localization.BadRequest] : message

            };
        }
        public Response<T> NotFound<T>(string message = null)
        {

            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[Localization.NotFound] : message

            };
        }
        public Response<T> Created<T>(T entity, object meta = null)
        {

            return new Response<T>
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringLocalizer[Localization.Created],
                Date = entity,
                Meta = meta

            };
        }


    }
}
