using School.Data.Bases;
using System.Linq.Expressions;

namespace School.Core.Bases
{
    public abstract class ISpecification<TEntity, TResult>
        where TEntity : BaseEntity
    {
        protected ISpecification(Expression<Func<TEntity, bool>> critria) => Critria = critria;


        public Expression<Func<TEntity, bool>>? Critria { get; }
        public List<Expression<Func<TEntity, object>>>? Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>>? OrderBy { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        public Expression<Func<TEntity, TResult>> Selector { get; private set; }
        protected void AddSelector(Expression<Func<TEntity, TResult>> selector) => Selector = selector;

        public int? Skip { get; set; }
        public int? Take { get; set; }
        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            Includes?.Add(include);
        }
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy) => OrderBy = orderBy;
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderbydesc) => OrderByDescending = orderbydesc;
    }
}
