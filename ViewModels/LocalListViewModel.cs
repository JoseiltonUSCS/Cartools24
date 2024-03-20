using Cartools.Models;

namespace Cartools.ViewModels
{
    public class LocalListViewModel
    {
        public IEnumerable<Local> Locals { get; set; }
        public string ServicoAtual {  get; set; }
    }
}
