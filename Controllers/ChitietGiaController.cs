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
    public class ChitietGiaController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: ChitietGia
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.ChitietGia.Include(c => c.GpMaNavigation).Include(c => c.LpMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: ChitietGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietGia = await _context.ChitietGia
                .Include(c => c.GpMaNavigation)
                .Include(c => c.LpMaNavigation)
                .FirstOrDefaultAsync(m => m.CtgMa == id);
            if (chitietGia == null)
            {
                return NotFound();
            }

            return View(chitietGia);
        }

        // GET: ChitietGia/Create
        public IActionResult Create()
        {
            ViewData["GpMa"] = new SelectList(_context.Giaphong, "GpMa", "GpMa");
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa");
            return View();
        }

        // POST: ChitietGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtgMa,CtgTgapdungTungay,CtgTgapdungDenngay,LpMa,GpMa")] ChitietGia chitietGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GpMa"] = new SelectList(_context.Giaphong, "GpMa", "GpMa", chitietGia.GpMa);
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", chitietGia.LpMa);
            return View(chitietGia);
        }

        // GET: ChitietGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietGia = await _context.ChitietGia.FindAsync(id);
            if (chitietGia == null)
            {
                return NotFound();
            }
            ViewData["GpMa"] = new SelectList(_context.Giaphong, "GpMa", "GpMa", chitietGia.GpMa);
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", chitietGia.LpMa);
            return View(chitietGia);
        }

        // POST: ChitietGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtgMa,CtgTgapdungTungay,CtgTgapdungDenngay,LpMa,GpMa")] ChitietGia chitietGia)
        {
            if (id != chitietGia.CtgMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietGiaExists(chitietGia.CtgMa))
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
            ViewData["GpMa"] = new SelectList(_context.Giaphong, "GpMa", "GpMa", chitietGia.GpMa);
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", chitietGia.LpMa);
            return View(chitietGia);
        }

        // GET: ChitietGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietGia = await _context.ChitietGia
                .Include(c => c.GpMaNavigation)
                .Include(c => c.LpMaNavigation)
                .FirstOrDefaultAsync(m => m.CtgMa == id);
            if (chitietGia == null)
            {
                return NotFound();
            }

            return View(chitietGia);
        }

        // POST: ChitietGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chitietGia = await _context.ChitietGia.FindAsync(id);
            _context.ChitietGia.Remove(chitietGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietGiaExists(string id)
        {
            return _context.ChitietGia.Any(e => e.CtgMa == id);
        }
    }
}
