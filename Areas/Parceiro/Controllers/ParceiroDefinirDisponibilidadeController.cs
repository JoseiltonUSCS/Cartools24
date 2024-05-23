using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Cartools.Models;
using Cartools.Context;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
        [Route("Parceiro/ParceiroDefinirDisponibilidadeAjax")]
        public async Task<IActionResult> DefinirDisponibilidadeAjax([Bind("Data,HorasDisponibilidade")] List<Disponibilidade> disponibilidades)
        {
            _logger.LogInformation("Chamando a função DefinirDisponibilidadeAjax");

            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            if (disponibilidades == null || !disponibilidades.Any())
            {
                _logger.LogWarning("A lista de disponibilidades está vazia ou nula.");
                return BadRequest(new { success = false, message = "A lista de disponibilidades não pode estar vazia." });
            }

            var userId = _userManager.GetUserId(User);
            var oficina = _context.Oficinas.FirstOrDefault(o => o.UserId == userId);

            if (oficina == null)
            {
                _logger.LogWarning("Oficina não encontrada para o usuário com ID: {UserId}", userId);
                return NotFound(new { success = false, message = "Oficina não encontrada." });
            }

            try
            {
                foreach (var disponibilidade in disponibilidades)
                {
                    // Validação: Verificar se a data é válida
                    if (disponibilidade.Data == default(DateTime))
                    {
                        _logger.LogWarning("Data inválida recebida: {Data}", disponibilidade.Data);
                        return BadRequest(new { success = false, message = "Uma ou mais datas são inválidas." });
                    }

                    // Validação: Verificar se há horas disponíveis
                    if (disponibilidade.HorasDisponibilidade == null || !disponibilidade.HorasDisponibilidade.Any())
                    {
                        _logger.LogWarning("Nenhuma hora disponível para a data: {Data}", disponibilidade.Data);
                        return BadRequest(new { success = false, message = "Uma ou mais datas não possuem horas disponíveis." });
                    }

                    disponibilidade.OficinaId = oficina.OficinaId;
                    _context.Disponibilidades.Add(disponibilidade);
                    await _context.SaveChangesAsync();

                    foreach (var hora in disponibilidade.HorasDisponibilidade)
                    {
                        // Validação: Verificar se a hora é válida
                        if (hora.Hora == default(TimeSpan))
                        {
                            _logger.LogWarning("Hora inválida recebida: {Hora}", hora.Hora);
                            return BadRequest(new { success = false, message = "Uma ou mais horas são inválidas." });
                        }

                        hora.DisponibilidadeId = disponibilidade.DisponibilidadeId;
                        hora.Data = disponibilidade.Data.Date.Add(hora.Hora); // Combina a data da disponibilidade com a hora selecionada
                        _context.HoraDisponibilidade.Add(hora);
                    }

                    await _context.SaveChangesAsync();
                }

                _logger.LogInformation("Disponibilidades e horas de disponibilidade salvas com sucesso.");
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar disponibilidades e horas.");
                return StatusCode(500, new { success = false, message = "Erro interno ao processar a solicitação." });
            }
        }
    }
}
