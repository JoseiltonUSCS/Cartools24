using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IOficinaRepository
    {

        IEnumerable<Oficina> Oficinas { get; }
        IEnumerable<Oficina> OficinasPreferidas { get; }

        Oficina GetOficinaById(int oficinaId);

    }
}
