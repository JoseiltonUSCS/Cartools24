using Cartools.Models;
using Cartools.Repositories;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cartools.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanoRepository _planoRepository;

        public HomeController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Planos = _planoRepository.Planos
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