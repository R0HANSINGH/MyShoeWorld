using Microsoft.AspNetCore.Mvc;
using MyShoeWorld.Dal;
using MyShoeWorld.Models;
using NuGet.Protocol.Core.Types;

namespace MyShoeWorld.UI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IShoeWorldRepository<Customer> _repository;

        public CustomersController(IShoeWorldRepository<Customer> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var customer = _repository.GetAll();
            return View(customer);
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Profile(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _repository.insert(customer);
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