using Microsoft.AspNetCore.Mvc;

namespace LienXoChongUS.Areas.Admin.Controllers
{
    public class StoreOwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}