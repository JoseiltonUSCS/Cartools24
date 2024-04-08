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
                //busca por cidade na barra de navegação
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

        // busca serviço por digitação no input do menu de navegação
        public IActionResult Details(int servicoId)
        {
            var servico = _servicoRepository.Servicos.FirstOrDefault(s => s.ServicoId == servicoId);
            return View(servico);
        }
        
        public ViewResult Search(string searchString)
        {
            //searchString - a busca é realizada a partir do que for digitado no campo de busca, que neste caso é o serviço desejado.

            IEnumerable<Servico> servicos;
            string localAtual = string.Empty;


            if (string.IsNullOrEmpty(searchString)) 
                
            {
                servicos = _servicoRepository.Servicos.OrderBy(s => s.ServicoId);
                localAtual = "Todos os Servicos";
            }
            else
            {
                servicos = _servicoRepository.Servicos
                          .Where(s => s.Nome.ToLower().Contains(searchString.ToLower()));

                if (servicos.Any())
                    localAtual = searchString;
                else
                    localAtual = "Nenhum serviço foi encontrado com esse filtro...";
            }
            return View("~/Views/Servico/List.cshtml", new ServicoListViewModel
            {
                
                Servicos = servicos.OrderBy(l => l.LocalId),
                LocalAtual = localAtual
            });
        }
        

       
    }
}
