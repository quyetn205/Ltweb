using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NmqDay09LabCF.Models;

namespace NmqDay09LabCF.Controllers
{
    public class NmqLoai_San_PhamController : Controller
    {
        private readonly NmqDay09LabCFContext _context;

        public NmqLoai_San_PhamController(NmqDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: NmqLoai_San_Pham
        public async Task<IActionResult> nmqIndex()
        {
            return View(await _context.tvcLoai_San_Phams.ToListAsync());
        }

        // GET: NmqLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmqLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.nmqId == id);
            if (nmqLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(nmqLoai_San_Pham);
        }

        // GET: NmqLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NmqLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nmqId,nmqMaLoai,nmqTenLoai,nmqTrangThai")] NmqLoai_San_Pham nmqLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nmqLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(nmqIndex));
            }
            return View(nmqLoai_San_Pham);
        }

        // GET: NmqLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmqLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (nmqLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(nmqLoai_San_Pham);
        }

        // POST: NmqLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nmqId,nmqMaLoai,nmqTenLoai,nmqTrangThai")] NmqLoai_San_Pham nmqLoai_San_Pham)
        {
            if (id != nmqLoai_San_Pham.nmqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nmqLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NmqLoai_San_PhamExists(nmqLoai_San_Pham.nmqId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(nmqIndex));
            }
            return View(nmqLoai_San_Pham);
        }

        // GET: NmqLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmqLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.nmqId == id);
            if (nmqLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(nmqLoai_San_Pham);
        }

        // POST: NmqLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nmqLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (nmqLoai_San_Pham != null)
            {
                _context.tvcLoai_San_Phams.Remove(nmqLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NmqLoai_San_PhamExists(long id)
        {
            return _context.tvcLoai_San_Phams.Any(e => e.nmqId == id);
        }
    }
}
