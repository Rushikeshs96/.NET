using Microsoft.EntityFrameworkCore;

namespace Dot_Net_WebApi.Domain
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> UsePageableAsync<T>(this IQueryable<T> query, Pagination pagination)
        {
            var totalItems = await query.CountAsync();
            var items = await query.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                   .Take(pagination.PageSize)
                                   .ToListAsync();

            return new PagedResult<T>(items, totalItems, pagination.PageNumber, pagination.PageSize);
        }
    }
}
