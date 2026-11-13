using Day3_TruongThiHaMy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3_TruongThiHaMy.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> _products = new List<Product>
        {
           new Product { ProductId = 1, ProductName = "Laptop", ProductPrice = 1500 },
           new Product { ProductId = 2, ProductName = "Mouse", ProductPrice = 25 },
           new Product { ProductId = 3, ProductName = "Keyboard", ProductPrice = 50 }
        };

        public IActionResult Index()
        {
            return View(_products);
        }
        // GET: ProductController


        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {

            return View();
        }
        // --- POST: Xử lý form gửi về ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product newProduct)
        {
            newProduct.ProductId = _products.Max(p => p.ProductId) + 1; // Sinh ID mới
            _products.Add(newProduct); // Thêm vào danh sách
            return RedirectToAction(nameof(Index));
        }
        // --- GET: Hiển thị form sửa sản phẩm ---
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        // --- POST: Nhận dữ liệu sau khi sửa ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.ProductId ==
            updatedProduct.ProductId);
            if (product == null)
                return NotFound();
            product.ProductName = updatedProduct.ProductName;
            product.ProductPrice = updatedProduct.ProductPrice;
            
            return RedirectToAction(nameof(Index));
        }
        // --- GET: Hiển thị xác nhận xóa ---
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // --- POST: Xác nhận xóa ---
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}