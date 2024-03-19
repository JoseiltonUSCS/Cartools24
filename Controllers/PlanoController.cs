using Cartools.Context;
using Cartools.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public IActionResult List()
        {
            ViewData["Titu"] = "Todos os 3 planos";
            ViewData["DHoje"] = DateTime.Now;
            var planos = _planoRepository.Planos;

            var totalPlanos = planos.Count();
            ViewBag.Planos = "Total de planos atualmente vendidos na plataforma: ";
            ViewBag.TotalCount = totalPlanos;

            return View(planos);
        }
    }
}
