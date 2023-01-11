using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Data;
using MyEticketApplication.Models;

namespace MyEticketApplication.Controllers
{
    public class TransportInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportInfo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportInfo.Include(t => t.TransportTypes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransportInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportInfo == null)
            {
                return NotFound();
            }

            var transportInfo = await _context.TransportInfo
                .Include(t => t.TransportTypes)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transportInfo == null)
            {
                return NotFound();
            }

            return View(transportInfo);
        }

        // GET: TransportInfo/Create
        public IActionResult Create()
        {
            ViewData["TransportTypeDdl"] = new SelectList(_context.TransportTypes, "TransportTypeId", "Name");
            return View();
        }

        // POST: TransportInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransportId,TransportName,TransportType,TransportOwnerName,TransportDescription,SeatNo,TransportTypeId")] TransportInfo transportInfo)
        {
            if (transportInfo.TransportTypeId !=0)
            {
                _context.Add(transportInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransportTypeDdl"] = new SelectList(_context.TransportTypes, "TransportTypeId", "Name");
            return View(transportInfo);
        }

        // GET: TransportInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportInfo == null)
            {
                return NotFound();
            }

            var transportInfo = await _context.TransportInfo.FindAsync(id);
            if (transportInfo == null)
            {
                return NotFound();
            }
            ViewData["TransportTypeDdl"] = new SelectList(_context.TransportTypes, "TransportTypeId", "Name");
            return View(transportInfo);
        }

        // POST: TransportInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransportId,TransportName,TransportType,TransportOwnerName,TransportDescription,SeatNo,TransportTypeId")] TransportInfo transportInfo)
        {
            if (id != transportInfo.TransportId)
            {
                return NotFound();
            }

            if (transportInfo.TransportTypeId !=0)
            {
                try
                {
                    _context.Update(transportInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportInfoExists(transportInfo.TransportId))
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
            ViewData["TransportTypeDdl"] = new SelectList(_context.TransportTypes, "TransportTypeId", "Name");
            return View(transportInfo);
        }

        // GET: TransportInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportInfo == null)
            {
                return NotFound();
            }

            var transportInfo = await _context.TransportInfo
                .Include(t => t.TransportTypes)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transportInfo == null)
            {
                return NotFound();
            }

            return View(transportInfo);
        }

        // POST: TransportInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportInfo'  is null.");
            }
            var transportInfo = await _context.TransportInfo.FindAsync(id);
            if (transportInfo != null)
            {
                _context.TransportInfo.Remove(transportInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportInfoExists(int id)
        {
          return (_context.TransportInfo?.Any(e => e.TransportId == id)).GetValueOrDefault();
        }
    }
}
