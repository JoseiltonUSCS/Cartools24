using Cartools.Models;

namespace Cartools.ViewModels
{
    public class PlanoListViewModel
    {
        public IEnumerable<Plano> Planos { get; set; }

        public IEnumerable<Plano> PlanosPreferidos { get; set; }
        public string TipoAtual {  get; set; }
    }
}
