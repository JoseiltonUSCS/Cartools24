using Cartools.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Controllers
{
    public class BuscaController : Controller
    {
        private readonly BuscaServicoRegiao buscaServicoRegiao;

        public BuscaController(BuscaServicoRegiao _buscaServicoRegiao)
        {
            buscaServicoRegiao = _buscaServicoRegiao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FindByCategoryAsync(string CategoriaNome)
        {
           
            ViewBag["CategoriaNome"] = CategoriaNome.ToString();
            

            var result = await buscaServicoRegiao.FindByCategoryAsync(CategoriaNome);
            return View(result);
        }
    }
}
