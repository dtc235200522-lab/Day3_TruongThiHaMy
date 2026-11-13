using Day3_TruongThiHaMy.Models;

namespace Day3_TruongThiHaMy.Services
{
    public class ProductService
    {
        public (List<Product> Items, int TotalRecords) Search(List<Product> sourceList, ProductSearchModel search)
        {
            var query = sourceList.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Keyword))
            {
                query = query.Where(p => p.ProductName != null &&
                                         p.ProductName.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase));
            }

            int page = (search != null && search.page > 0) ? search.page : 1;
            int pageSize = (search != null && search.pageSize > 0) ? search.pageSize : 5;

            int totalRecords = query.Count();
            var items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (items, totalRecords);
        }
    }
}