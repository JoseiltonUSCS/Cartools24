/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Cartools.Models;
using Cartools.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Cartools.Areas.Parceiro.Controllers
{
    [Area("Parceiro")]
    public class ParceiroSalvarDisponibilidadeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ParceiroDefinirDisponibilidadeController> _logger;


        public ParceiroSalvarDisponibilidadeController(AppDbContext context, UserManager<IdentityUser> userManager, ILogger<ParceiroDefinirDisponibilidadeController> logger)
        {
            _context = context;
            _logger = logger;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalvarDisponibilidade([FromBody] DisponibilidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Obter o ID do usuário atualmente logado
                var userId = _userManager.GetUserId(User);

                // Obter a oficina associada ao usuário
                var oficina = _context.Oficinas.FirstOrDefault(o => o.UserId == userId);

                // Verificar se a oficina foi encontrada
                if (oficina == null)
                {
                    return NotFound();
                }

                // Criar uma nova disponibilidade e configurar a oficina
                var disponibilidade = new Disponibilidade
                {
                    OficinaId = oficina.OficinaId,
                    // Adicione outras propriedades da disponibilidade conforme necessário
                };

                // Adicionar a disponibilidade ao contexto e salvar as mudanças
                _context.Disponibilidades.Add(disponibilidade);
                await _context.SaveChangesAsync();

                // Salvar as horas de disponibilidade
                foreach (var hora in model.HorasDisponibilidade)
                {
                    if (TimeSpan.TryParse(hora.Hora, out TimeSpan horaConvertida))
                    {
                        var horaDisponibilidade = new HoraDisponibilidade
                        {
                            DisponibilidadeId = disponibilidade.DisponibilidadeId,
                            Hora = horaConvertida
                        };
                        _context.HoraDisponibilidade.Add(horaDisponibilidade);
                    }
                    else
                    {
                        ModelState.AddModelError("HorasDisponibilidade", "Formato de hora inválido: " + hora.Hora);
                        // Ou você pode fazer outra coisa, como registrar o erro em algum lugar
                    }
                }

                await _context.SaveChangesAsync();

                _logger.LogInformation("Disponibilidade adicionada e horas de disponibilidade salvas.");

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }
    }
}*/
