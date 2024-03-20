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
            locaisListViewModel.ServicoAtual = "Aqui será apresentada a lista das cidades de atuação. Isso está vindo de LocalController e será apresentado na Local/List que está referenciando LocalListViewModel que representa a minha ViewModel(lembrar de apagar depois e substituir por algo mais relevante.) ";

            return View(locaisListViewModel);

        }
    }
}
