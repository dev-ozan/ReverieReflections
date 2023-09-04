using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ReverieReflections.Areas.Models;
using ReverieReflections.Data;

namespace ReverieReflections.Areas.Identity
{
    [Authorize]
    [Area("Identity")]
    public class MakaleController : Controller
    {
        private readonly ApplicationDbContext _context;
  

       
        public MakaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Identity/Makale
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Makale.Include(p => p.Yazar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Identity/Makale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Makale == null)
            {
                return NotFound();
            }

            var makale = await _context.Makale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // GET: Identity/Makale/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identity/Makale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // TODO: resim varsa yükle ve ismini kaydedilecek entity'ye aktar
                Makale makale = new Makale()
                {
                    YazarId = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                    MakaleAdi = vm.MakaleAdi,
                    Content = vm.Content,
                    //Image = "Buraya -varsa- Kaydedilen Resmin Adı Gelecek"
                };
                _context.Add(makale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Identity/Makale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Makale == null)
            {
                return NotFound();
            }

            var post = await _context.Makale.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", post.YazarId);
            return View(post);
        }

        // POST: Identity/Makale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakaleAdi,Content,YazarId")] Makale makale)
        {
            if (id != makale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakaleExists(makale.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", makale.YazarId);
            return View(makale);
        }

        // GET: Identity/Makale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Makale == null)
            {
                return NotFound();
            }

            var makale = await _context.Makale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // POST: Identity/Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Makale == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Makale'  is null.");
            }
            var makale = await _context.Makale.FindAsync(id);
            if (makale != null)
            {
                _context.Makale.Remove(makale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakaleExists(int id)
        {
            return (_context.Makale?.Any(e => e.Id == id)).GetValueOrDefault();
        }
     
    }
}
