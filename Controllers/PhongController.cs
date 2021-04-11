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
    public class PhongController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: Phong
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.Phong.Include(p => p.LpMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: Phong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong
                .Include(p => p.LpMaNavigation)
                .FirstOrDefaultAsync(m => m.PMa == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: Phong/Create
        public IActionResult Create()
        {
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa");
            return View();
        }

        // POST: Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PMa,PTen,PSlgiuong,PMota,PTrangthai,LpMa")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", phong.LpMa);
            return View(phong);
        }

        // GET: Phong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", phong.LpMa);
            return View(phong);
        }

        // POST: Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PMa,PTen,PSlgiuong,PMota,PTrangthai,LpMa")] Phong phong)
        {
            if (id != phong.PMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.PMa))
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
            ViewData["LpMa"] = new SelectList(_context.Loaiphong, "LpMa", "LpMa", phong.LpMa);
            return View(phong);
        }

        // GET: Phong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong
                .Include(p => p.LpMaNavigation)
                .FirstOrDefaultAsync(m => m.PMa == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phong = await _context.Phong.FindAsync(id);
            _context.Phong.Remove(phong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(string id)
        {
            return _context.Phong.Any(e => e.PMa == id);
        }
    }
}
