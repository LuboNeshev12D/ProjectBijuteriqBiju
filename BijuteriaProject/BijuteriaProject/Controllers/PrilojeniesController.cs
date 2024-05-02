using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BijuteriaProject.Data;
using Microsoft.VisualBasic;

namespace BijuteriaProject.Controllers
{
    public class PrilojeniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrilojeniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prilojenies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prilojeniq.ToListAsync());
        }

        // GET: Prilojenies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prilojenie = await _context.Prilojeniq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prilojenie == null)
            {
                return NotFound();
            }

            return View(prilojenie);
        }

        // GET: Prilojenies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prilojenies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,RegDate")] Prilojenie prilojenie)
        {
            prilojenie.RegDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Prilojeniq.Add(prilojenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prilojenie);
        }

        // GET: Prilojenies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prilojenie = await _context.Prilojeniq.FindAsync(id);
            if (prilojenie == null)
            {
                return NotFound();
            }
            return View(prilojenie);
        }

        // POST: Prilojenies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,RegDate")] Prilojenie prilojenie)
        {
            if (id != prilojenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    prilojenie.RegDate = DateTime.Now;
                    _context.Prilojeniq.Update(prilojenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrilojenieExists(prilojenie.Id))
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
            return View(prilojenie);
        }

        // GET: Prilojenies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prilojenie = await _context.Prilojeniq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prilojenie == null)
            {
                return NotFound();
            }

            return View(prilojenie);
        }

        // POST: Prilojenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prilojenie = await _context.Prilojeniq.FindAsync(id);
            if (prilojenie != null)
            {
                _context.Prilojeniq.Remove(prilojenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrilojenieExists(int id)
        {
            return _context.Prilojeniq.Any(e => e.Id == id);
        }
    }
}
