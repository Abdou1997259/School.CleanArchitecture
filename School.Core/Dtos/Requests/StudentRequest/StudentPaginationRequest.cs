using School.Data.Constants.Enums;

namespace School.Core.Dtos.Requests.StudentRequest
{
    public class StudentPaginationRequest : PaginationRequest
    {
        public StudentOrderingEnum OrderBy { get; set; }
        public TypeOfOrdering TypeOfOrdering { get; set; }
    }
}
