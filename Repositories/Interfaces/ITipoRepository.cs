using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface ITipoRepository
    {
        IEnumerable<Tipo> Tipos { get; }
        Plano GetTipoById(int tipoId);
    }
}
