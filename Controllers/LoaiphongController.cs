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
    public class LoaiphongController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: Loaiphong
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loaiphong.ToListAsync());
        }

        // GET: Loaiphong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphong
                .FirstOrDefaultAsync(m => m.LpMa == id);
            if (loaiphong == null)
            {
                return NotFound();
            }

            return View(loaiphong);
        }

        // GET: Loaiphong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaiphong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LpMa,LpTenloai")] Loaiphong loaiphong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiphong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiphong);
        }

        // GET: Loaiphong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphong.FindAsync(id);
            if (loaiphong == null)
            {
                return NotFound();
            }
            return View(loaiphong);
        }

        // POST: Loaiphong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LpMa,LpTenloai")] Loaiphong loaiphong)
        {
            if (id != loaiphong.LpMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiphong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiphongExists(loaiphong.LpMa))
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
            return View(loaiphong);
        }

        // GET: Loaiphong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphong = await _context.Loaiphong
                .FirstOrDefaultAsync(m => m.LpMa == id);
            if (loaiphong == null)
            {
                return NotFound();
            }

            return View(loaiphong);
        }

        // POST: Loaiphong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaiphong = await _context.Loaiphong.FindAsync(id);
            _context.Loaiphong.Remove(loaiphong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiphongExists(string id)
        {
            return _context.Loaiphong.Any(e => e.LpMa == id);
        }
    }
}
