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
            var planos = _planoRepository.Planos;
            return View(planos);
        }
    }
}
