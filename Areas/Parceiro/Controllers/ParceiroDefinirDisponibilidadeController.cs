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
    }
}