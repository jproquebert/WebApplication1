using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OtsController : Controller
    {
        private readonly PruebaContext _context;

        public OtsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Ots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ots.ToListAsync());
        }

        // GET: Ots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ots = await _context.Ots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ots == null)
            {
                return NotFound();
            }

            return View(ots);
        }

        // GET: Ots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Startdate,Enddate,Reference,Invoice,Department,Costcenter,Account,ProjectCode,Description,Contractor,LaborPrice,MaterialPrice,StateProject,Userid,Comment,State,CreatedAt,UpdatedAt,Idteam")] Ots ots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ots);
        }

        // GET: Ots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ots = await _context.Ots.FindAsync(id);
            if (ots == null)
            {
                return NotFound();
            }
            return View(ots);
        }

        // POST: Ots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Startdate,Enddate,Reference,Invoice,Department,Costcenter,Account,ProjectCode,Description,Contractor,LaborPrice,MaterialPrice,StateProject,Userid,Comment,State,CreatedAt,UpdatedAt,Idteam")] Ots ots)
        {
            if (id != ots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Ots)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                 proposedValues[property] = proposedValue;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                            _context.Update(ots);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ots);
        }

        // GET: Ots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ots = await _context.Ots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ots == null)
            {
                return NotFound();
            }

            return View(ots);
        }

        // POST: Ots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ots = await _context.Ots.FindAsync(id);
            _context.Ots.Remove(ots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtsExists(int id)
        {
            return _context.Ots.Any(e => e.Id == id);
        }
    }
}
