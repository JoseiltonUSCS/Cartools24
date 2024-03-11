using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;

namespace Cartools.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly AppDbContext _context;

        public PlanoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Plano> Planos => _context.Planos;        
        public Plano GetPlanoById(int PlanoId)
        {
            return _context.Planos.FirstOrDefault(s => s.PlanoId == PlanoId);
        }
    }
}
