using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyShoeWorld.Dal;
using MyShoeWorld.Models;
using Newtonsoft.Json;


namespace MyShoeWorld.UI.Controllers
{

        public class CartsController : Controller
        {
            private readonly IShoeWorldRepository<Product> _shoeWorldRepository;

            public CartsController(IShoeWorldRepository<Product> shoeWorldRepository)
            {
                this._shoeWorldRepository = shoeWorldRepository;
            }

            public IActionResult MyCart(int productId)
            {
                List<CartDetails> allCartProducts;
                HttpContext.Session.SetInt32("CustomerId", 1);
                if (HttpContext.Session.Get<Cart>("Cart") == null)
                {
                    var cart = new Cart()
                    {
                        CustomerId = Convert.ToInt32(HttpContext.Session.GetInt32("CustomerId")),
                        CartDate = DateTime.Now
                    };
                    HttpContext.Session.Set<Cart>("Cart", cart);
                }
                if (HttpContext.Session.Get<List<CartDetails>>("CartDetails") == null)
                {
                    allCartProducts = new List<CartDetails>();
                    CartDetails details = new CartDetails()
                    {
                        ProductId = productId,
                        Quantity = 1,
                        Size = 7,
                    };
                    allCartProducts.Add(details);
                    HttpContext.Session.Set<List<CartDetails>>("CartDetails", allCartProducts);
                }
                else
                {
                    //var obj = HttpContext.Session.Get<List<CartDetails>>("CartDetails");
                    allCartProducts = HttpContext.Session.Get<List<CartDetails>>("CartDetails");
                    CartDetails details = new CartDetails()
                    {
                        ProductId = productId,
                        Quantity = 1,
                        Size = 7,
                    };
                    allCartProducts.Add(details);
                    HttpContext.Session.Set<List<CartDetails>>("CartDetails", allCartProducts);
                }
                allCartProducts = HttpContext.Session.Get<List<CartDetails>>("CartDetails");
                var cartProducts = from cart in allCartProducts
                                   join
                                   storeproducts in _shoeWorldRepository.GetAll()
                                   on cart.ProductId equals storeproducts.ProductId
                                   select storeproducts;
                return View(cartProducts);

            }
        }
    }


