using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;

namespace Cartools.Repositories
{
    public class OficinaRepository : IOficinaRepository
    {
        private readonly AppDbContext _context;

        public OficinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Oficina> Oficinas => _context.Oficinas;
    }
}
