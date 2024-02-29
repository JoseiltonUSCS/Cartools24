using Microsoft.AspNetCore.Mvc;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Cartools.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IServicoRepository servicoRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _servicoRepository = servicoRepository;
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
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int servicoId)
        {
            var servicoSelecionado = _servicoRepository.Servicos
                                    .FirstOrDefault(p => p.ServicoId == servicoId);

            if (servicoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(servicoSelecionado);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int servicoId)
        {
            var servicoSelecionado = _servicoRepository.Servicos
                                    .FirstOrDefault(p => p.ServicoId == servicoId);

            if (servicoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(servicoSelecionado);
            }
            return RedirectToAction("Index");
        }

        
    }
}