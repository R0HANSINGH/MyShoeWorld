using Microsoft.AspNetCore.Mvc;

namespace MyShoeWorld.UI.Controllers
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
