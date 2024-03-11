using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{
    public class PlanoController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
