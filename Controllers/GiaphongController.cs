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
    public class GiaphongController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: Giaphong
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giaphong.ToListAsync());
        }

        // GET: Giaphong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaphong = await _context.Giaphong
                .FirstOrDefaultAsync(m => m.GpMa == id);
            if (giaphong == null)
            {
                return NotFound();
            }

            return View(giaphong);
        }

        // GET: Giaphong/Create
        public class CreateID
            {
                public static string CreateID_ByteText()
                {
                    string IDstring = DateTime.Now.ToString("MMddHHmmss");
                    return IDstring;
                }
            }
        public IActionResult Create()
        {
            Giaphong gp = new Giaphong();
            gp.GpMa = CreateID.CreateID_ByteText();
            return View(gp);
        }

        // POST: Giaphong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GpMa,GpTheongay,GpTheotuan,GpTheothang,GpQuadem")] Giaphong giaphong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaphong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaphong);
        }

        // GET: Giaphong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaphong = await _context.Giaphong.FindAsync(id);
            if (giaphong == null)
            {
                return NotFound();
            }
            return View(giaphong);
        }

        // POST: Giaphong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GpMa,GpTheongay,GpTheotuan,GpTheothang,GpQuadem")] Giaphong giaphong)
        {
            if (id != giaphong.GpMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaphong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaphongExists(giaphong.GpMa))
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
            return View(giaphong);
        }

        // GET: Giaphong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaphong = await _context.Giaphong
                .FirstOrDefaultAsync(m => m.GpMa == id);
            if (giaphong == null)
            {
                return NotFound();
            }

            return View(giaphong);
        }

        // POST: Giaphong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var giaphong = await _context.Giaphong.FindAsync(id);
            _context.Giaphong.Remove(giaphong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaphongExists(string id)
        {
            return _context.Giaphong.Any(e => e.GpMa == id);
        }
    }
}
