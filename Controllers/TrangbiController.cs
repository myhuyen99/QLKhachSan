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
    public class TrangbiController : Controller
    {
        private readonly QLKhachSanContext _context;

        public TrangbiController(QLKhachSanContext context)
        {
            _context = context;
        }

        // GET: Trangbi
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.Trangbi.Include(t => t.PMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: Trangbi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangbi = await _context.Trangbi
                .Include(t => t.PMaNavigation)
                .FirstOrDefaultAsync(m => m.TbMa == id);
            if (trangbi == null)
            {
                return NotFound();
            }

            return View(trangbi);
        }

        // GET: Trangbi/Create
        public IActionResult Create()
        {
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa");
            return View();
        }

        // POST: Trangbi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TbMa,TbTen,TbMota,PMa")] Trangbi trangbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trangbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", trangbi.PMa);
            return View(trangbi);
        }

        // GET: Trangbi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangbi = await _context.Trangbi.FindAsync(id);
            if (trangbi == null)
            {
                return NotFound();
            }
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", trangbi.PMa);
            return View(trangbi);
        }

        // POST: Trangbi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TbMa,TbTen,TbMota,PMa")] Trangbi trangbi)
        {
            if (id != trangbi.TbMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trangbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangbiExists(trangbi.TbMa))
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
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", trangbi.PMa);
            return View(trangbi);
        }

        // GET: Trangbi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangbi = await _context.Trangbi
                .Include(t => t.PMaNavigation)
                .FirstOrDefaultAsync(m => m.TbMa == id);
            if (trangbi == null)
            {
                return NotFound();
            }

            return View(trangbi);
        }

        // POST: Trangbi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trangbi = await _context.Trangbi.FindAsync(id);
            _context.Trangbi.Remove(trangbi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrangbiExists(string id)
        {
            return _context.Trangbi.Any(e => e.TbMa == id);
        }
    }
}
