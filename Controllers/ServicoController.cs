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
        /*
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
        */




        //Filtra por Serviço e Cidade
        public ViewResult Search(string searchString, string local)
        {   
            IEnumerable<Servico> servicos;
            string localAtual = string.Empty;
           
            if (string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(local))                 
            {
                servicos = _servicoRepository.Servicos.OrderBy(s => s.Nome);
                localAtual = "Todos os Servicos encontrados";      
            }
            else if(!string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(local))
            {
                //Filtrar por Serviço
                servicos = _servicoRepository.Servicos
                          .Where(s => s.Nome.ToLower().Contains(searchString.ToLower()));

                if (servicos.Any())
                    localAtual = "Resultado da busca por Serviço:";
            }
            else if(string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(local))
            {
                //Filtrar por Cidade
                servicos = _servicoRepository.Servicos.Where(l => l.Local.Cidade.Contains(local)).OrderBy(l => l.Local.Cidade);
                if (servicos.Any())
                    localAtual = "Resultado da busca por Cidade:";
                else
                    localAtual = "Nenhum servico foi encontrado";
            }
            else //Filtrar por cidade e Serviço
            {
                //Filtrar por cidade
                servicos = _servicoRepository.Servicos.Where(l => l.Local.Cidade.Equals(local)).OrderBy(l => l.Local.Cidade);

                //Filtrar por serviço
                servicos = servicos.Where(s => s.Nome.Contains(searchString)).OrderBy(s => s.Nome);
                if (servicos.Any())
                    localAtual = $"Resultado da busca por \"Serviço\" na \"Cidade\" de {local}";
                else
                    localAtual = "Nenhum servico foi encontrado";
            }

            return View("~/Views/Servico/List.cshtml", new ServicoListViewModel
            {

                Servicos = servicos.OrderBy(s => s.Nome),
                LocalAtual = localAtual
            });
        }
    }
}

