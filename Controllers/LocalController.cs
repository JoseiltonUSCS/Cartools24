using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
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
            //var local = _localRepository.Locals;
            //return View(local);

            var locaisListViewModel = new LocalListViewModel();
            locaisListViewModel.Locals = _localRepository.Locals;
            locaisListViewModel.ServicoAtual = "Aqui será apresentada...???";

            return View(locaisListViewModel);

        }
    }
}
