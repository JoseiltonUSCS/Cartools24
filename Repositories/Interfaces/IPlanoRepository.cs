using Cartools.Models;

namespace Cartools.Repositories.Interfaces
{
    public interface IPlanoRepository
    {
        IEnumerable<Plano> Planos { get; }
        Plano GetPlanoById(int PlanoId);

    }
}