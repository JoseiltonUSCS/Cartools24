using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cartools.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly AppDbContext _context;

        public PlanoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Plano> Planos => _context.Planos.Include(t => t.Tipo);

        public IEnumerable<Plano> PlanosPreferidos => _context.Planos.Where(p => p.IsPlanoPreferido).Include(t => t.Tipo);

        public Plano GetPlanoById(int planoId)
        {
            return _context.Planos.FirstOrDefault(p => p.PlanoId == planoId);
        }
    }
}
