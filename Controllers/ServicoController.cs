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
        {    //Evolução do código - inicial
            //var servicos = _servicoRepository.Servicos;
            //return View(servicos);

            //Evolução do código - lista todos os serviços
            //var servicoListViewModel = new ServicoListViewModel();
            //servicoListViewModel.Servicos = _servicoRepository.Servicos;
            //servicoListViewModel.CategoriaAtual = "TextoFixo - Categoria Atual - TextFixo";
            //return View(servicoListViewModel);

            //Evolução do código - lista serviços por categoria
            IEnumerable<Servico> servicos;
            string categoriaAtual = string.Empty;

            //Se eu não definir nenhuma categoria o retorno será todos os serviços, ordenado por ID,  do contrário o retorno trará apenas os serviços inclusos na categoria solicitada

            if(string.IsNullOrEmpty(categoria))
            {
                servicos = _servicoRepository.Servicos.OrderBy(s => s.ServicoId);
                categoriaAtual = "Todos os serviços";
            }
            else
            {
                if(string.Equals("Limpeza", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    servicos = _servicoRepository.Servicos.Where(s => s.Categoria.CategoriaNome.Equals("Limpeza")).OrderBy(s => s.Nome);
                }   
                else
                if (string.Equals("Pintura", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    servicos = _servicoRepository.Servicos.Where(s => s.Categoria.CategoriaNome.Equals("Pintura")).OrderBy(s => s.Nome);
                }
                else
                {
                    servicos = _servicoRepository.Servicos.Where(s => s.Categoria.CategoriaNome.Equals("Manutencao")).OrderBy(s => s.Nome);
                }

                categoriaAtual = categoria;
            }

            var servicosListViewModel = new ServicoListViewModel
            {
                Servicos = servicos,
                CategoriaAtual = categoriaAtual,
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
