using Calendario.Repositories.Interfaces;
using Cartools.Context;
using Cartools.Repositories.Interfaces;
using Cartools.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cartools.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepository _calendarioRepository;

        public AgendamentoController(IAgendamentoRepository calendarioRepository)
        {
            _calendarioRepository = calendarioRepository;
        }

        public IActionResult Index()
        {
            /*var agendamentosListViewModel = new AgendamentosListViewModel
            {
                Agendamentos = _calendarioRepository.Agendamentos
            };*/

            return View();
        }

        public IActionResult Detalhes(int agendamentoId)
        {
            var agendamento = _calendarioRepository.GetAgendamentoById(agendamentoId);
            return View(agendamento);
        }

        public IActionResult Agendar(DateTime dataHora)
        {
            // validar a disponibilidade e salvar o agendamento
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Agendamento()
        {
            // Lógica para agendamento
            return View();
        }

        public IActionResult DefinirHorarios()
        {
            // Uma página para que as empresas possam definir os horários disponíveis
            return View();
        }
    }
}
