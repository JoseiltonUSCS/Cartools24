using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IOficinaRepository
    {
        IEnumerable<Oficina> Oficinas { get; }

    }
}
