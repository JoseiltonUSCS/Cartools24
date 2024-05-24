using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cartools.Context;
using Cartools.Models;

namespace Cartools.Areas.Parceiro.Controllers
{
    [Area("Parceiro")]
    public class ParceiroServprodController : Controller
    {
        private readonly AppDbContext _context;

        public ParceiroServprodController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Parceiro/ParceiroServprod
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Servicos.Include(s => s.Categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Parceiro/ParceiroServprod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Parceiro/ParceiroServprod/Create
        public IActionResult Create()
        {
            ViewBag.LocalId = new SelectList(_context.Locals, "LocalId", "Cidade");
            ViewBag.OficinaId = new SelectList(_context.Oficinas, "OficinaId", "OficinaNome");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Parceiro/ParceiroServprod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsServicoPreferido,EmEstoque,CategoriaId")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocalsId"] = new SelectList(_context.Locals, "LocalId", "Cidade");
            ViewData["OficinasId"] = new SelectList(_context.Oficinas, "OficinaId", "OficinaNome");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", servico.CategoriaId);
            return View(servico);
        }

        // GET: Parceiro/ParceiroServprod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewBag.LocalId = new SelectList(_context.Locals, "LocalId", "Cidade", servico.LocalId);
            ViewBag.OficinaId = new SelectList(_context.Oficinas, "OficinaId", "OficinaNome", servico.OficinaId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", servico.CategoriaId);
            return View(servico);
        }

        // POST: Parceiro/ParceiroServprod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsServicoPreferido,EmEstoque,CategoriaId")] Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", servico.CategoriaId);
            ViewData["LocalId"] = new SelectList(_context.Locals, "LocalId", "Cidade", servico.LocalId);
            ViewData["OficinaId"] = new SelectList(_context.Oficinas, "OficinaId", "OficinaNome", servico.OficinaId);

            return View(servico);
        }

        // GET: Parceiro/ParceiroServprod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Parceiro/ParceiroServprod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'AppDbContext.Servicos'  is null.");
            }
            var servico = await _context.Servicos.FindAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
          return _context.Servicos.Any(e => e.ServicoId == id);
        }
    }
}
