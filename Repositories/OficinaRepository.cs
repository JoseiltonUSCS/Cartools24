using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cartools.Repositories
{
    public class OficinaRepository : IOficinaRepository
    {
        private readonly AppDbContext _context;

        public OficinaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Oficina> Oficinas => _context.Oficinas
                                    .Include(s => s.Servico);
        public IEnumerable<Oficina> OficinaPreferida => _context.Oficinas.
                                    Where(o => o.IsOficinaPreferida)
                                    .Include(o => o.Servico);

        public Oficina GetOficinaById(int oficinaId)
        {
            return _context.Oficinas.FirstOrDefault(o => o.OficinaId == oficinaId);
        }
    }
}
