using Microsoft.AspNetCore.Mvc;
using MVC04.Models;
using MVC04.Repositories;

namespace MVC04.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: /Product/NewProduct
        public IActionResult NewProduct()
        {
            return View();
        }

        // POST: /Product/NewProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewProduct(Product product)
        {
            if (_repository.IsNameExists(product.ProductName))
            {
                ModelState.AddModelError("ProductName", "Tên mặt hàng đã tồn tại, vui lòng chọn tên khác");
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _repository.Add(product);

            ModelState.Clear();
            ViewBag.SuccessMessage = "Thêm sản phẩm thành công!";
            return View(new Product());
        }

        // GET: /Product/ProductMgr
        public IActionResult ProductMgr()
        {
            List<Product> products = _repository.GetAll();
            return View(products);
        }

        // GET: /Product/DeleteProduct/5
        public IActionResult DeleteProduct(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("ProductMgr");
        }

        // POST: /Product/DeleteProductAjax/5  (Bài 5.1 - xóa bằng AJAX)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductAjax(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy mặt hàng cần xóa" });
            }

            try
            {
                _repository.Delete(id);
                return Json(new { success = true, message = "Xóa mặt hàng thành công" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { success = false, message = "Xóa mặt hàng thất bại" });
            }
        }
        // GET: /Product/ProductList
public IActionResult ProductList()
{
    List<Product> products = _repository.GetAll();
    return View(products);
}

// GET: /Product/ProductDetail/5
public IActionResult ProductDetail(int id)
{
    var product = _repository.GetById(id);

    if (product == null)
    {
        return NotFound();
    }

    return View(product);
}
    }
}