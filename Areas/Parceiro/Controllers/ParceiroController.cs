using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Areas.Parceiro.Controllers
{
    [Area("Parceiro")]
    public class ParceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
