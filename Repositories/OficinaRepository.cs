using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Oficina> OficinasPreferidas => _context.Oficinas.Where(o => o.IsOficinaPreferida).Include(o => o.OficinaNome);

        /*
public IEnumerable<Oficina> Oficinas => _context.Oficinas
.Include(os => os.Servico);
public IEnumerable<Oficina> OficinaPreferida => _context.Oficinas.
Where(o => o.IsOficinaPreferida)
.Include(os => os.Servico);
*/
        public Oficina GetOficinaById(int oficinaId)
        {
            return _context.Oficinas.FirstOrDefault(o => o.OficinaId == oficinaId);
        }

    }
}
