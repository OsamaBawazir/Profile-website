using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;

namespace Profile.Controlers
{
    public class ProfileItemsController : Controller
    {
        private readonly DataContext _context;

        public ProfileItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: ProfileItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfileItems.ToListAsync());
        }

        // GET: ProfileItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileItem = await _context.ProfileItems
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profileItem == null)
            {
                return NotFound();
            }

            return View(profileItem);
        }

        // GET: ProfileItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectName,Descreption,ImgUrl,ID")] ProfileItem profileItem)
        {
            if (ModelState.IsValid)
            {
                profileItem.ID = Guid.NewGuid();
                _context.Add(profileItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileItem);
        }

        // GET: ProfileItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileItem = await _context.ProfileItems.FindAsync(id);
            if (profileItem == null)
            {
                return NotFound();
            }
            return View(profileItem);
        }

        // POST: ProfileItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProjectName,Descreption,ImgUrl,ID")] ProfileItem profileItem)
        {
            if (id != profileItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileItemExists(profileItem.ID))
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
            return View(profileItem);
        }

        // GET: ProfileItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileItem = await _context.ProfileItems
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profileItem == null)
            {
                return NotFound();
            }

            return View(profileItem);
        }

        // POST: ProfileItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profileItem = await _context.ProfileItems.FindAsync(id);
            _context.ProfileItems.Remove(profileItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileItemExists(Guid id)
        {
            return _context.ProfileItems.Any(e => e.ID == id);
        }
    }
}
