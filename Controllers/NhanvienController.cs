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
    public class NhanvienController : Controller
    {
        private readonly QLKhachSanContext _context = new QLKhachSanContext();
// private bool IsAuthenticated(string UserName, string PassWord)
//         {
//             return (UserName == "nhan9961" && PassWord == "12345");
//         }
        public IActionResult Login()
                {
                    return View();
                }
        public ActionResult Validate(Nhanvien nv)
        {
            var acomptec_qlthptContext = _context.Nhanvien.Where(s => s.NvTendn == nv.NvTendn);
            if(acomptec_qlthptContext.Any()){
                if(acomptec_qlthptContext.Where(s => s.NvMatkhau == nv.NvMatkhau).Any()){
                    
                    return Json(new { status = true, message = "Login Successfull!"});
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!"});
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!"});
            }
        }
        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhanvien.ToListAsync());
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.NvMa == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
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
            Nhanvien nv = new Nhanvien();
            nv.NvMa = CreateID.CreateID_ByteText();
            return View(nv);
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NvMa,NvTendn,NvMatkhau")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NvMa,NvTendn,NvMatkhau")] Nhanvien nhanvien)
        {
            if (id != nhanvien.NvMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.NvMa))
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
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.NvMa == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            _context.Nhanvien.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
            return _context.Nhanvien.Any(e => e.NvMa == id);
        }
    }
}
