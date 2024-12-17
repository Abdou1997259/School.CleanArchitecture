using Microsoft.EntityFrameworkCore;
using School.Core.Bases;
using School.Data.Bases;

namespace School.Infrastructure.Bases
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TResult> GetQuery<TEntity, TResult>(
         IQueryable<TEntity> query,
         ISpecification<TEntity, TResult> spec
     ) where TEntity : BaseEntity
        {
            // Apply Criteria
            if (spec.Critria is not null)
            {
                query = query.Where(spec.Critria);
            }

            // Apply Includes
            if (spec.Includes is not null)
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            // Apply Sorting
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            // Apply Selector
            if (spec.Selector is null)
            {
                throw new InvalidOperationException("A selector must be provided to project the result.");
            }

            return query.Select(spec.Selector);
        }

    }
}
