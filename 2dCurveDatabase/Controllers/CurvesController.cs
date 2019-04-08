using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurveDatabase2d.Data;
using CurveDatabase2d.Models;

namespace CurveDatabase2d.Controllers
{
    public class CurvesController : Controller
    {
        private readonly CurveDatabase2dContext _context;

        public CurvesController(CurveDatabase2dContext context)
        {
            _context = context;
        }

        // GET: Curves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Curves.ToListAsync());
        }

        // GET: Curves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curve = await _context.Curves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curve == null)
            {
                return NotFound();
            }

            return View(curve);
        }

        // GET: Curves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Formula,Id,Added,AddedUserId")] Curve curve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curve);
        }

        // GET: Curves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curve = await _context.Curves.FindAsync(id);
            if (curve == null)
            {
                return NotFound();
            }
            return View(curve);
        }

        // POST: Curves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Formula,Id,Added,AddedUserId")] Curve curve)
        {
            if (id != curve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurveExists(curve.Id))
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
            return View(curve);
        }

        // GET: Curves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curve = await _context.Curves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curve == null)
            {
                return NotFound();
            }

            return View(curve);
        }

        // POST: Curves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curve = await _context.Curves.FindAsync(id);
            _context.Curves.Remove(curve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurveExists(int id)
        {
            return _context.Curves.Any(e => e.Id == id);
        }
    }
}
