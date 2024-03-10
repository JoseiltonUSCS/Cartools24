using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface ILocalRepository
    {
        IEnumerable<Local> Locals { get; }

    }
}
