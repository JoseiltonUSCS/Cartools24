using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
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

        public IActionResult Index()
        {
            var planoListViewModel = new PlanoListViewModel
            {
                PlanosPreferidos = _planoRepository.PlanosPreferidos
            };

            return View(planoListViewModel);
        }
        public IActionResult List()
        {
            var planosListViewModel = new PlanoListViewModel();
            planosListViewModel.Planos = _planoRepository.Planos;
            planosListViewModel.TipoAtual = "Tipo Atual";

            return View(planosListViewModel);
        }
        public IActionResult Details(int planoId)
        {
            var plano = _planoRepository.Planos.FirstOrDefault(p => p.PlanoId == planoId);
            return View(plano);
        }
    }
}
