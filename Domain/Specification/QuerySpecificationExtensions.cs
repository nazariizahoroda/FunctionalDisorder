using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Specification
{
    public static class QuerySpecificationExtensions
    {
        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
        {
            if (spec.Includes.Count > 0)
            {
                query = spec.Includes
                    .Aggregate(query,
                        (current, include) => current.Include(include));
            }

            if (spec.IncludeStrings.Count > 0)
            {
                query = spec.IncludeStrings
                    .Aggregate(query,
                        (current, include) => current.Include(include));
            }

            return query.Where(spec.Criteria);
        }

        public static async Task<bool> SpecifyAnyAsync<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
        {
            if (spec.Includes != null && spec.Includes.Count > 0)
            {
                query = spec.Includes
                    .Aggregate(query,
                        (current, include) => current.Include(include));
            }

            if (spec.IncludeStrings != null && spec.IncludeStrings.Count > 0)
            {
                query = spec.IncludeStrings
                    .Aggregate(query,
                        (current, include) => current.Include(include));
            }

            return await query.AnyAsync(spec.Criteria);
        }
    }
}
