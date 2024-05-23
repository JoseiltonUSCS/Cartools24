using Cartools.Context;
using Cartools.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Areas.Parceiro.Controllers
{
    [Area("Parceiro")]
    [Authorize(Roles = "Parceiro")]
    public class ParceiroDefinirDisponibilidadeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ParceiroDefinirDisponibilidadeController> _logger;

        public ParceiroDefinirDisponibilidadeController(AppDbContext context, UserManager<IdentityUser> userManager, ILogger<ParceiroDefinirDisponibilidadeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Entrando na controller");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("DefinirDisponibilidade")]
        public async Task<IActionResult> DefinirDisponibilidade(Disponibilidade disponibilidade)
        {
            _logger.LogInformation("Chamando a função DefinirDisponibilidade");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            // Obter o ID do usuário atualmente logado
            var userId = _userManager.GetUserId(User);

            // Obter a oficina associada ao usuário
            var oficina = _context.Oficinas.FirstOrDefault(o => o.UserId == userId);

            // Verificar se a oficina foi encontrada
            if (oficina == null)
            {
                return NotFound();
            }

            // Configurar o ID da oficina na disponibilidade
            disponibilidade.OficinaId = oficina.OficinaId;

            // Adicionar a disponibilidade ao contexto e salvar as mudanças
            _context.Disponibilidades.Add(disponibilidade);
            await _context.SaveChangesAsync();

            // Salvar as horas de disponibilidade
            foreach (var hora in disponibilidade.HorasDisponibilidade)
            {
                hora.DisponibilidadeId = disponibilidade.DisponibilidadeId;
                _context.HoraDisponibilidade.Add(hora);
            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("Disponibilidade adicionada e horas de disponibilidade salvas.");

            // Adicionando um log para verificar se as horas de disponibilidade foram salvas corretamente
            foreach (var hora in disponibilidade.HorasDisponibilidade)
            {
                _logger.LogInformation($"Hora de disponibilidade salva: {hora.Horario}");
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
