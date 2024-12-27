using System.Linq.Expressions;

namespace PropLoader
{
    public class ListOptions<TEntity> : List<Expression<Func<TEntity, object>>> where TEntity : class
    {
    }
}
