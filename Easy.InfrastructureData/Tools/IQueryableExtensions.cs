using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Tools
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query) where T : class
        {
            var navigationProperties = typeof(T)
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            (typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()) ||
                            typeof(ICollection<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition())) ||
                            !p.PropertyType.IsValueType && p.PropertyType != typeof(string));

            foreach (var property in navigationProperties)
            {
                query = query.Include(property.Name);
            }

            return query;
        }
    }

}
