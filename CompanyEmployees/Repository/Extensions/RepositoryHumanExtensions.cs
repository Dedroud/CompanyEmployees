using Entities.Models;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryHumanExtensions
    {
        public static IQueryable<Human> FilterHumans(this IQueryable<Human> humans, uint minAge, uint maxAge) => humans.Where(e => (e.Age >= minAge && e.Age <= maxAge));
        public static IQueryable<Human> Search(this IQueryable<Human> humans, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return humans;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return humans.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<Human> Sort(this IQueryable<Human> humans, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return humans.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Human>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return humans.OrderBy(e => e.Name);
            return humans.OrderBy(orderQuery);
        }
    }
}
