using Cartools.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Views.Shared.Components
{
    public class ServicoMenu : ViewComponent
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoMenu(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IViewComponentResult Invoke()
        {
            var servicos = _servicoRepository.Servicos.OrderBy(s => s.Nome);
            return View(servicos);
        }
    }
}
