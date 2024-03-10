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

        public IActionResult List(string local)
        {

            IEnumerable<Servico> servicos;
            string localAtual = string.Empty;

            //Se eu não definir nenhuma categoria o retorno será todos os serviços, ordenado por ID,  do contrário o retorno trará apenas os serviços inclusos na categoria solicitada

            if (string.IsNullOrEmpty(local))
            {
                servicos = _servicoRepository.Servicos.OrderBy(s => s.ServicoId);
                localAtual = "Todos os serviços";
            }
            else
            {   
                servicos = _servicoRepository.Servicos.Where( l => l.Local.Cidade.Equals(local)).OrderBy(s => s.Nome);

                localAtual = local;
            }

            var servicosListViewModel = new ServicoListViewModel
            {
                Servicos = servicos,
                LocalAtual = localAtual
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
            string localAtual = string.Empty;


            if (string.IsNullOrEmpty(searchString))
            {
                servicos = _servicoRepository.Servicos.OrderBy(l => l.ServicoId);
                localAtual = "Todos os Servicos";
            }
            else
            {
                servicos = _servicoRepository.Servicos
                          .Where(s => s.Nome.ToLower().Contains(searchString.ToLower()));

                if (servicos.Any())
                    localAtual = "Servicos";
                else
                    localAtual = "Nenhum servico foi encontrado";
            }
            return View("~/Views/Servico/List.cshtml", new ServicoListViewModel
            {
                
                Servicos = servicos.OrderBy(l => l.LocalId),
                LocalAtual = localAtual
            });
        }
    }
}
