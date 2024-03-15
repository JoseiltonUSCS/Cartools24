using Cartools.Models;
using Cartools.Repositories.Interfaces;

namespace Cartools.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        public IEnumerable<Tipo> Tipos => throw new NotImplementedException();

        public Plano GetTipoById(int tipoId)
        {
            throw new NotImplementedException();
        }
    }
}
