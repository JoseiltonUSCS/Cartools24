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
        public IActionResult Details(int servicoId)
        {
            var servico = _servicoRepository.Servicos.FirstOrDefault(s => s.ServicoId == servicoId);
            return View(servico);
        }

        //Filtra por Serviço e Cidade
        public ViewResult Search(string searchString, string local)
        {   
            IEnumerable<Servico> servicos;
            string resultadoBusca = string.Empty;
           
            if ((searchString == "Serviço") && (local == "Cidade"))                 
            {
                servicos = _servicoRepository.Servicos.OrderBy(s => s.Nome);
                resultadoBusca = "Todos os Servicos encontrados";      
            }
            else if(!(searchString == "Serviço") && (local == "Cidade"))
            {
                //Filtrar por Serviço
                servicos = _servicoRepository.Servicos
                          .Where(s => s.Nome.ToLower().Contains(searchString.ToLower()));

                if (servicos.Any())
                    resultadoBusca = "Resultado da busca por Serviço:";
            }
            else if((searchString == "Serviço") && !(local == "Cidade"))
            {
                //Filtrar por Cidade
                servicos = _servicoRepository.Servicos.Where(l => l.Local.Cidade.Contains(local)).OrderBy(l => l.Local.Cidade);
                if (servicos.Any())
                    resultadoBusca = "Resultado da busca por Cidade:";
                else
                    resultadoBusca = "Nenhum serviço/cidade foi encontrado";
            }
            else //Filtrar por cidade e Serviço
            {
                //Filtrar por cidade
                servicos = _servicoRepository.Servicos.Where(l => l.Local.Cidade.Equals(local)).OrderBy(l => l.Local.Cidade);

                //Filtrar por serviço
                servicos = servicos.Where(s => s.Nome.Contains(searchString)).OrderBy(s => s.Nome);
                if (servicos.Any())
                    resultadoBusca = $"Resultado da busca por \"Serviço\" na \"Cidade\" de {local}";
                else
                    resultadoBusca = "Nenhum serviço foi encontrado com esse filtro...";
            }

            return View("~/Views/Servico/List.cshtml", new ServicoListViewModel
            {

                Servicos = servicos.OrderBy(s => s.Nome),
                ResultadoBusca = resultadoBusca
            });
        }
    }
}

