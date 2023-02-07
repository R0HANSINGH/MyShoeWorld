using Microsoft.AspNetCore.Mvc;
using MyShoeWorld.Dal;
using MyShoeWorld.Models;

namespace MyShoeWorld.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IShoeWorldRepository<Category> _repository;

        public CategoriesController(IShoeWorldRepository<Category> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
           
            var categories = _repository.GetAll();
            return View(categories);
        }
        // by default get http
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        //[HttpPut]
        public IActionResult New(Category category)
        {
            if(ModelState.IsValid)
            {
                _repository.insert(category);
                int result = _repository.SaveChanges();
                if(result>0)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }
    }
}
