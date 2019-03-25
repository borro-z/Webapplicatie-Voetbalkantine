using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LidController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LidController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lid
        public async Task<IActionResult> Index()
        {
            return View(await _context.leden.ToListAsync());
        }

        // GET: Lid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lid = await _context.leden
                .FirstOrDefaultAsync(m => m.LidId == id);
            if (lid == null)
            {
                return NotFound();
            }

            return View(lid);
        }

        // GET: Lid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LidId,Naam,Geboortedatum,Tussenvoegsel,Achternaam,Aanhef,Geslacht,PostAdres,Plaats,Tel,Mobiel,Email,SoortLid,Betaald")] Lid lid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lid);
        }

        // GET: Lid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lid = await _context.leden.FindAsync(id);
            if (lid == null)
            {
                return NotFound();
            }
            return View(lid);
        }

        // POST: Lid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LidId,Naam,Geboortedatum,Tussenvoegsel,Achternaam,Aanhef,Geslacht,PostAdres,Plaats,Tel,Mobiel,Email,SoortLid,Betaald")] Lid lid)
        {
            if (id != lid.LidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LidExists(lid.LidId))
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
            return View(lid);
        }

        // GET: Lid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lid = await _context.leden
                .FirstOrDefaultAsync(m => m.LidId == id);
            if (lid == null)
            {
                return NotFound();
            }

            return View(lid);
        }

        // POST: Lid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lid = await _context.leden.FindAsync(id);
            _context.leden.Remove(lid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Lid/jarigen
        public async Task<IActionResult> Jarigen()
        {
            return View(await _context.leden
                            .Where(x => x.Geboortedatum != null)
                            .OrderBy(x => x.Geboortedatum.Month)
                            .ThenBy(x => x.Geboortedatum.Day)
                            .ToListAsync()
                        );
        }

        private bool LidExists(int id)
        {
            return _context.leden.Any(e => e.LidId == id);
        }
    }
}
