using System.Linq.Expressions;

namespace PropLoader
{
    public class IncludeOptions<TEntity> where TEntity : class
    {
        public ListOptions<TEntity> Properties { get; } = [];

        public IncludeOptions(ListOptions<TEntity> properties)
        {
            Properties = properties;
        }

        public IncludeOptions(params Expression<Func<TEntity, object>>[] properties)
        {
            Properties.AddRange(properties);
        }
    }
}
