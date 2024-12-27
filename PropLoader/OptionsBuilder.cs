using Microsoft.EntityFrameworkCore;

namespace PropLoader
{
    public static class OptionsBuilder
    {
        public static IQueryable<TEntity> Build<TEntity>(IQueryable<TEntity> query, IncludeOptions<TEntity>? includeOption = null) where TEntity : class
        {
            if (includeOption?.Properties != null || includeOption?.Properties.Count > 0)
            {
                foreach (var property in includeOption.Properties)
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
