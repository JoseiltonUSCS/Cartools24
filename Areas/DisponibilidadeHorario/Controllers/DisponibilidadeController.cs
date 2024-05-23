using Microsoft.AspNetCore.Mvc;

namespace Cartools.Areas.Disponibilidade.Controllers
{
    [Area("DisponibilidadeHorario")]
    public class DisponibilidadeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
