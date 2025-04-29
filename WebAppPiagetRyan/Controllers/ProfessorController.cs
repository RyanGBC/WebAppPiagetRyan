using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPiagetRyan.Data;
using WebAppPiagetRyan.Models;

namespace WebAppPiagetRyan.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Base.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.Base
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Base @base)
        {
            if (ModelState.IsValid)
            {
                @base.Id = Guid.NewGuid();
                _context.Add(@base);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@base);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.Base.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }
            return View(@base);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] Base @base)
        {
            if (id != @base.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@base);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseExists(@base.Id))
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
            return View(@base);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.Base
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @base = await _context.Base.FindAsync(id);
            if (@base != null)
            {
                _context.Base.Remove(@base);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseExists(Guid id)
        {
            return _context.Base.Any(e => e.Id == id);
        }
    }
}
