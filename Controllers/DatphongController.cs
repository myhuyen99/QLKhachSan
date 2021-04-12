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
    public class DatphongController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();

        [HttpGet]
        public ActionResult MyAction(string search)
        {
        //do whatever you need with the parameter, 
        //like using it as parameter in Linq to Entities or Linq to Sql, etc. 
        //Suppose your search result will be put in variable "result".
        ViewData["KhMa"] = search;
        return View();
        }
        // GET: Datphong
        public async Task<IActionResult> Index()
        {
            var qLKhachSanContext = _context.Datphong.Include(d => d.KhMaNavigation).Include(d => d.NvMaNavigation);
            return View(await qLKhachSanContext.ToListAsync());
        }

        // GET: Datphong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _context.Datphong
                .Include(d => d.KhMaNavigation)
                .Include(d => d.NvMaNavigation)
                .FirstOrDefaultAsync(m => m.DpMa == id);
            if (datphong == null)
            {
                return NotFound();
            }

            return View(datphong);
        }

        // GET: Datphong/Create
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
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhHoten");
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvTendn");
            Datphong dp = new Datphong();
            dp.DpMa = CreateID.CreateID_ByteText();
            return View(dp);
        }

        // POST: Datphong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DpMa,DpTgnhan,DpTgtra,KhMa,NvMa")] Datphong datphong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datphong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa", datphong.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "KhMa", datphong.NvMa);
            return View(datphong);
        }

        // GET: Datphong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _context.Datphong.FindAsync(id);
            if (datphong == null)
            {
                return NotFound();
            }
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhHoten", datphong.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvTendn", datphong.NvMa);
            return View(datphong);
        }

        // POST: Datphong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DpMa,DpTgnhan,DpTgtra,KhMa,NvMa")] Datphong datphong)
        {
            if (id != datphong.DpMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datphong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatphongExists(datphong.DpMa))
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
            ViewData["KhMa"] = new SelectList(_context.Khachhang, "KhMa", "KhMa", datphong.KhMa);
            ViewData["NvMa"] = new SelectList(_context.Nhanvien, "NvMa", "NvMa", datphong.NvMa);
            return View(datphong);
        }

        // GET: Datphong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = await _context.Datphong
                .Include(d => d.KhMaNavigation)
                .Include(d => d.NvMaNavigation)
                .FirstOrDefaultAsync(m => m.DpMa == id);
            if (datphong == null)
            {
                return NotFound();
            }

            return View(datphong);
        }

        // POST: Datphong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var datphong = await _context.Datphong.FindAsync(id);
            _context.Datphong.Remove(datphong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatphongExists(string id)
        {
            return _context.Datphong.Any(e => e.DpMa == id);
        }
    }
}
