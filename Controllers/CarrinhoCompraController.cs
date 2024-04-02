using Microsoft.AspNetCore.Mvc;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Cartools.Repositories;

namespace Cartools.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IPlanoRepository _planoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IPlanoRepository planoRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _planoRepository = planoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
                public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int planoId)
        {
            var planoSelecionado = _planoRepository.Planos
                                    .FirstOrDefault(p => p.PlanoId == planoId);

            if (planoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(planoSelecionado);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int planoId)
        {
            var planoSelecionado = _planoRepository.Planos
                                    .FirstOrDefault(p => p.PlanoId == planoId);

            if (planoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(planoSelecionado);
            }
            return RedirectToAction("Index");
        }        
    }
}