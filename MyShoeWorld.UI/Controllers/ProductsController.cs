using MyShoeWorld.Dal;
using MyShoeWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyShoeWorld.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IShoeWorldRepository<Product> _repository;

        public ProductsController(IShoeWorldRepository<Product> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("A", "A");
            Console.WriteLine(HttpContext.Session.Id);
            var products = _repository.GetAll();
            return View(products);
        }
        //parameterized Route
        public IActionResult CategoryProducts(int id)
        {

            var products=_repository.GetAll().Where(p=>p.CategoryId==id);
            return View("Index",products);
        }
       public IActionResult Details(int id) 
        {
            var products = from product in _repository.GetAll()
                           where product.ProductId == id
                           select product;
            return View(products);
        }
        public IActionResult New(Product  products)
        {
            if (ModelState.IsValid)
            {
                _repository.insert(products);
                int result = _repository.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}
