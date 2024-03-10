using Cartools.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{
    public class LocalController : Controller
    {
        private readonly ILocalRepository _localRepository;
        public LocalController(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }
        public IActionResult List()
        {
            var local = _localRepository.Locals;
            return View(local);
        }
    }
}
