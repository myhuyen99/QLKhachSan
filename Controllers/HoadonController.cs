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
    public class HoadonController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        // GET: Hoadon
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.Hoadon.Include(h => h.KhMaNavigation).Include(h => h.NvMaNavigation).Include(h => h.PMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: Hoadon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.KhMaNavigation)
                .Include(h => h.NvMaNavigation)
                .Include(h => h.PMaNavigation)
                .FirstOrDefaultAsync(m => m.HdMa == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Hoadon/Create
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
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa");
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvMa");
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa");
            Hoadon hd = new Hoadon();
            hd.HdMa = CreateID.CreateID_ByteText();
            return View(hd);
        }

        // POST: Hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HdMa,HdTgnhan,HdTgtra,HdTongtien,KhMa,NvMa,PMa")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa", hoadon.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvMa", hoadon.NvMa);
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", hoadon.PMa);
            return View(hoadon);
        }

        // GET: Hoadon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa", hoadon.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvMa", hoadon.NvMa);
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", hoadon.PMa);
            return View(hoadon);
        }

        // POST: Hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HdMa,HdTgnhan,HdTgtra,HdTongtien,KhMa,NvMa,PMa")] Hoadon hoadon)
        {
            if (id != hoadon.HdMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.HdMa))
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
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa", hoadon.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvMa", hoadon.NvMa);
            ViewData["PMa"] = new SelectList(_context.Phong, "PMa", "PMa", hoadon.PMa);
            return View(hoadon);
        }

        // GET: Hoadon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.KhMaNavigation)
                .Include(h => h.NvMaNavigation)
                .Include(h => h.PMaNavigation)
                .FirstOrDefaultAsync(m => m.HdMa == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hoadon = await _context.Hoadon.FindAsync(id);
            _context.Hoadon.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(string id)
        {
            return _context.Hoadon.Any(e => e.HdMa == id);
        }
    }
}
