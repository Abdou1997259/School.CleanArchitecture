using System.ComponentModel;

namespace School.Core.Dtos.Requests
{
    public class PaginationRequest
    {
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public string? Search { get; set; }


    }
}
