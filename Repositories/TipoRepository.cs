using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;

namespace Cartools.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly AppDbContext _context;

        public TipoRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Tipo> Tipos => _context.Tipos;
    }
}
