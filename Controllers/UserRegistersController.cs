using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDB.Data;
using WebDB.Models;

namespace WebDB.Controllers
{
    public class UserRegistersController : Controller
    {
        private readonly UsersContext _context;

        public UserRegistersController(UsersContext context)
        {
            _context = context;
        }

        // GET: UserRegisters
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRegister.ToListAsync());
        }

        // GET: UserRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegister == null)
            {
                return NotFound();
            }

            return View(userRegister);
        }

        // GET: UserRegisters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Email,Password,Confirm_Password,Role")] UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userRegister);
        }

        // GET: UserRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegister.FindAsync(id);
            if (userRegister == null)
            {
                return NotFound();
            }
            return View(userRegister);
        }

        // POST: UserRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Email,Password,Confirm_Password,Role")] UserRegister userRegister)
        {
            if (id != userRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegisterExists(userRegister.Id))
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
            return View(userRegister);
        }

        // GET: UserRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegister == null)
            {
                return NotFound();
            }

            return View(userRegister);
        }

        // POST: UserRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userRegister = await _context.UserRegister.FindAsync(id);
            _context.UserRegister.Remove(userRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegisterExists(int id)
        {
            return _context.UserRegister.Any(e => e.Id == id);
        }
    }
}
