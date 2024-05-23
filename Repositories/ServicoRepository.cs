using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cartools.Repositories
{

    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servico> Servicos => _context.Servicos
                                    .Include(l => l.Local).ThenInclude(o => o.Oficina);

        public IEnumerable<Servico> ServicosPreferidos => _context.Servicos.
                                    Where(s => s.IsServicoPreferido)
                                    .Include(l => l.Local).ThenInclude(o => o.Oficina);

        public Servico GetServicoById(int ServicoId)
        {
            return _context.Servicos.FirstOrDefault(s => s.ServicoId == ServicoId);
        }
    }
}
