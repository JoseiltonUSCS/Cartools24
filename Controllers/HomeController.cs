using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cartools.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicoRepository _servicoRepository;

        public HomeController(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IActionResult Index()
        {
            TempData["Nome"] = "Joseilton";

            var homeViewModel = new HomeViewModel
            {
                ServicosPreferidos = _servicoRepository.ServicosPreferidos
            };

            return View(homeViewModel);
        }

        public IActionResult SobreNos()
        {
            return View();
        }

        public IActionResult SejaParceiro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
            });
        }
    }
}