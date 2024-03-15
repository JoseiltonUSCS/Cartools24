using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        IEnumerable<Servico> Servicos { get; }

        IEnumerable<Servico> ServicosPreferidos { get; }

        IEnumerable<Servico> ServicosOficinas { get; }

        IEnumerable<Servico> ServicosPreferidosOficina { get; }

        Servico GetServicoById(int ServicoId);

    }
}
