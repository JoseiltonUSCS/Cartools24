using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;

namespace Cartools.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly AppDbContext _context;
        public LocalRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Local> Locals => _context.Locals;
    }
}

