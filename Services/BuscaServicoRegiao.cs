using Cartools.Context;
using Cartools.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq;

namespace Cartools.Services
{
    public class BuscaServicoRegiao
    {
        private readonly AppDbContext context;

        public BuscaServicoRegiao(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Categoria>> FindByCategoryAsync(string CategoriaNome)
        {
            var resultado = from obj in context.Categorias select obj;

                     

            return await resultado
                        .Include(s => s.CategoriaNome)
                        .OrderByDescending( x => x.CategoriaId)
                        .ToListAsync();
        }
    }
}
