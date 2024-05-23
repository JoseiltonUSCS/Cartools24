using Cartools.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{
    public class OficinaController : Controller
    {
        private readonly IOficinaRepository _oficinaRepository;

        public OficinaController(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }
        public ActionResult List()
        {
            var oficinas = _oficinaRepository.Oficinas;
            return View(oficinas);
        }
    }
}