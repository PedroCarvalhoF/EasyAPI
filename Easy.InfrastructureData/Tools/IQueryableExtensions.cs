using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Easy.InfrastructureData.Tools
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query, int maxDepth = 2) where T : class
        {
            return IncludeNavigationProperties(query, typeof(T), string.Empty, maxDepth);
        }

        private static IQueryable<T> IncludeNavigationProperties<T>(IQueryable<T> query, Type type, string path, int depth) where T : class
        {
            if (depth == 0) return query;

            var navigationProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                           .Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string) ||
                                                       p.PropertyType.IsGenericType &&
                                                       (typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()) ||
                                                       typeof(ICollection<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition())));

            foreach (var property in navigationProperties)
            {
                var newPath = string.IsNullOrEmpty(path) ? property.Name : $"{path}.{property.Name}";
                query = query.Include(newPath);

                var propertyType = property.PropertyType.IsGenericType ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;

                // Recursively include navigation properties of the related entities
                query = IncludeNavigationProperties(query, propertyType, newPath, depth - 1);
            }

            return query;
        }
    }
}
