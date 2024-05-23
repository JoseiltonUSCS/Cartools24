using Cartools.Models;

namespace Cartools.ViewModels
{
    public class PedidoServicoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
