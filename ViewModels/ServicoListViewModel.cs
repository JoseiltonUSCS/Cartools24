using Cartools.Models;

namespace Cartools.ViewModels
{
    public class ServicoListViewModel
    {
        public IEnumerable<Servico> Servicos { get; set; }
        public string LocalAtual { get; set; }

    }
}
