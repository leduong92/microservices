using Microsoft.AspNetCore.Mvc;

namespace Microservices.ProductApi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
