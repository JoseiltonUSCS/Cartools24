using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NPoco;

namespace Cartools.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoController(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Servico> servicos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                servicos = _servicoRepository.Servicos.OrderBy(l => l.ServicoId);
                categoriaAtual = "Todos os servicos";
            }
            else
            {
                servicos = _servicoRepository.Servicos
                          .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                          .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var servicosListViewModel = new ServicoListViewModel
            {
                Servicos = servicos,
                CategoriaAtual = categoriaAtual
            };

            return View(servicosListViewModel);
        }

        public IActionResult Details(int servicoId)
        {
            var servico = _servicoRepository.Servicos.FirstOrDefault(l => l.ServicoId == servicoId);
            return View(servico);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Servico> servicos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                servicos = _servicoRepository.Servicos.OrderBy(p => p.ServicoId);
                categoriaAtual = "Todos os Servicos";
            }
            else
            {
                servicos = _servicoRepository.Servicos
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (servicos.Any())
                    categoriaAtual = "Servicos";
                else
                    categoriaAtual = "Nenhum servico foi encontrado";
            }

            return View("~/Views/Servico/List.cshtml", new ServicoListViewModel
            {
                Servicos = servicos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
