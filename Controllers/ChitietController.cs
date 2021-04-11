using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKhachSan.Models;

namespace QLKhachSan.Controllers
{
    public class ChitietController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: Chitiet
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.Chitiet.Include(c => c.DvMaNavigation).Include(c => c.HdMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: Chitiet/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiet = await _context.Chitiet
                .Include(c => c.DvMaNavigation)
                .Include(c => c.HdMaNavigation)
                .FirstOrDefaultAsync(m => m.CtMa == id);
            if (chitiet == null)
            {
                return NotFound();
            }

            return View(chitiet);
        }

        // GET: Chitiet/Create
        public IActionResult Create()
        {
            ViewData["DvMa"] = new SelectList(_context.Dichvu, "DvMa", "DvMa");
            ViewData["HdMa"] = new SelectList(_context.Hoadon, "HdMa", "HdMa");
            return View();
        }

        // POST: Chitiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtMa,CtGia,CtThanhtien,HdMa,DvMa")] Chitiet chitiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DvMa"] = new SelectList(_context.Dichvu, "DvMa", "DvMa", chitiet.DvMa);
            ViewData["HdMa"] = new SelectList(_context.Hoadon, "HdMa", "HdMa", chitiet.HdMa);
            return View(chitiet);
        }

        // GET: Chitiet/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiet = await _context.Chitiet.FindAsync(id);
            if (chitiet == null)
            {
                return NotFound();
            }
            ViewData["DvMa"] = new SelectList(_context.Dichvu, "DvMa", "DvMa", chitiet.DvMa);
            ViewData["HdMa"] = new SelectList(_context.Hoadon, "HdMa", "HdMa", chitiet.HdMa);
            return View(chitiet);
        }

        // POST: Chitiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtMa,CtGia,CtThanhtien,HdMa,DvMa")] Chitiet chitiet)
        {
            if (id != chitiet.CtMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietExists(chitiet.CtMa))
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
            ViewData["DvMa"] = new SelectList(_context.Dichvu, "DvMa", "DvMa", chitiet.DvMa);
            ViewData["HdMa"] = new SelectList(_context.Hoadon, "HdMa", "HdMa", chitiet.HdMa);
            return View(chitiet);
        }

        // GET: Chitiet/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiet = await _context.Chitiet
                .Include(c => c.DvMaNavigation)
                .Include(c => c.HdMaNavigation)
                .FirstOrDefaultAsync(m => m.CtMa == id);
            if (chitiet == null)
            {
                return NotFound();
            }

            return View(chitiet);
        }

        // POST: Chitiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chitiet = await _context.Chitiet.FindAsync(id);
            _context.Chitiet.Remove(chitiet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietExists(string id)
        {
            return _context.Chitiet.Any(e => e.CtMa == id);
        }
    }
}
