using System.Net;
using System.Text.Json;

namespace School.Core.Bases
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data, string message = null)
        {
            Message = message;
            Date = data;
            Succeeded = true;

        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;

        }

        public bool Succeeded { get; set; }
        public object Meta { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Date { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
