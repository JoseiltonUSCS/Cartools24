using Cartools.Models;
using Cartools.Repositories;
using Cartools.Repositories.Interfaces;

namespace Cartools.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Servico> ServicosPreferidos { get; set; }
    }

}
