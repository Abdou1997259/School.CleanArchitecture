namespace School.Core.Bases
{
    public class PaginationResult<T>
    {
        public List<T> Data { get; set; }
        public PaginationResult(List<T> data)
        {
            Data = data;
        }
        internal PaginationResult(
            bool succeeded,
            List<T> data = default,
            List<string> messages = null,
            int count = 0,
            int page = 1,
            int pageSize = 10


            )
        {

            Data = data;
            CurrentPage = page;

            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);



        }

        public static PaginationResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new(true, data, null, count, page, pageSize);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

    }
}
