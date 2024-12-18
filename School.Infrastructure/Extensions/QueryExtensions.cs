
using Microsoft.EntityFrameworkCore;
using School.Core.Bases;

namespace School.Infrastructure.Extensions
{
    public static class QueryableExtension
    {
        public static async Task<PaginationResult<T>> ToPaginationListAsync<T>(
      this IQueryable<T> source, int pageNumber, int pageSize)
      where T : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            try
            {
                // Get the total count of items
                int totalCount = await source.CountAsync();
                if (totalCount == 0)
                    return PaginationResult<T>.Success(new List<T>(), totalCount, pageNumber, pageSize);

                // Log the query for debugging
                var query = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                Console.WriteLine(query.ToQueryString());

                // Fetch the paginated items
                var items = await query.ToListAsync();

                return PaginationResult<T>.Success(items, totalCount, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
