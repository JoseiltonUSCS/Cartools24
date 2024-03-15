using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OpenXmlPowerTools;
using System.Linq;

namespace Cartools.Repositories
{
    
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext contexto)
        {
                _context = contexto;
        }

        public IEnumerable<Servico> Servicos => _context.Servicos
                                    .Include(l => l.Local);

        public IEnumerable<Servico> ServicosPreferidos => _context.Servicos.
                                    Where(s => s.IsServicoPreferido)
                                    .Include(l => l.Local);

        public IEnumerable<Servico> ServicosOficinas => _context.Servicos
                                    .Include(o => o.Oficina);

        public IEnumerable<Servico> ServicosPreferidosOficina => _context.Servicos.
                                    Where(s => s.IsServicoPreferido)
                                    .Include(o => o.Oficina);

        public Servico GetServicoById(int ServicoId)        
        {
            return _context.Servicos.FirstOrDefault(s => s.ServicoId == ServicoId);
        }
    }
}
