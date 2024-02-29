using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        IEnumerable<Servico> Servicos { get; }

        IEnumerable<Servico> ServicoPreferido { get; }

        Servico GetServicoById(int ServicoId);

    }
}
