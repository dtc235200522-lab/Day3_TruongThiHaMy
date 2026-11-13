using Day3_TruongThiHaMy.Models;
using Day3_TruongThiHaMy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day3_TruongThiHaMy.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly ProductService _productService = new ProductService();

        public IActionResult Index([FromQuery] ProductSearchModel search)
        {
            // Thay "products" bằng đúng tên biến danh sách bên ProductController của bạn (ví dụ _products)
            var (items, totalRecords) = _productService.Search(ProductController._products, search);

            int page = (search != null && search.page > 0) ? search.page : 1;
            int pageSize = (search != null && search.pageSize > 0) ? search.pageSize : 5;

            ViewBag.Search = search;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(items);
        }
    }
}