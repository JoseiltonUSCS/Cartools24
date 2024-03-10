using Cartools.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartools.Components
{
    public class LocalMenu : ViewComponent
    {
        private readonly ILocalRepository _localRepository;

        public LocalMenu(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public IViewComponentResult Invoke()
        {
            var local = _localRepository.Locals.OrderBy(l => l.Cidade);
            return View(local);
        }
    }
}
