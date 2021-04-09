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
    public class DichvuController : Controller
    {
        private readonly QLKhachSanContext _context;

        public DichvuController(QLKhachSanContext context)
        {
            _context = context;
        }

        // GET: Dichvu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dichvu.ToListAsync());
        }

        // GET: Dichvu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .FirstOrDefaultAsync(m => m.DvMa == id);
            if (dichvu == null)
            {
                return NotFound();
            }

            return View(dichvu);
        }

        // GET: Dichvu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dichvu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DvMa,DvTen,DvGia,DvSlnhap,DvTonkho")] Dichvu dichvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dichvu);
        }

        // GET: Dichvu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu.FindAsync(id);
            if (dichvu == null)
            {
                return NotFound();
            }
            return View(dichvu);
        }

        // POST: Dichvu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DvMa,DvTen,DvGia,DvSlnhap,DvTonkho")] Dichvu dichvu)
        {
            if (id != dichvu.DvMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichvuExists(dichvu.DvMa))
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
            return View(dichvu);
        }

        // GET: Dichvu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .FirstOrDefaultAsync(m => m.DvMa == id);
            if (dichvu == null)
            {
                return NotFound();
            }

            return View(dichvu);
        }

        // POST: Dichvu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dichvu = await _context.Dichvu.FindAsync(id);
            _context.Dichvu.Remove(dichvu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichvuExists(string id)
        {
            return _context.Dichvu.Any(e => e.DvMa == id);
        }
    }
}
