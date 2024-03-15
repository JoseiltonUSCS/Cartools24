using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IPlanoRepository
    {
        IEnumerable<Plano> Planos { get; }
        IEnumerable<Plano> PlanosPreferidos { get; }
        Plano GetPlanoById(int planoId);
    }
}
