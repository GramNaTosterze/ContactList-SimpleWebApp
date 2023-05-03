using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactList_SimpleWebApp.Data;
using ContactList_SimpleWebApp.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ContactList_SimpleWebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactList_SimpleWebAppContext _context;

        public ContactsController(ContactList_SimpleWebAppContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
              return _context.Contact != null ? 
                          View(await _context.Contact.ToListAsync()) :
                          Problem("Entity set 'ContactList_SimpleWebAppContext.Contact'  is null.");
        }

        // GET: Contacts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Email == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Categories"] = Categories();
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Name,Surname,Email,Category,Password,Phone,BirthDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = Categories();
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Surname,Email,Category,Password,Phone,BirthDate")] Contact contact)
        {
            if (id != contact.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Email))
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
            ViewData["Categories"] = Categories();
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Email == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Contact == null)
            {
                return Problem("Entity set 'ContactList_SimpleWebAppContext.Contact'  is null.");
            }
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BusinessSubCategory(string email)
        {
            return PartialView("_Business", _context.Contact.Find("jk@mail.com"));
        }
        public ActionResult OtherSubCategory(string email)
        {
            return PartialView("_Other", _context.Contact.Find("jk@mail.com"));
        }


        private bool ContactExists(string id)
        {
          return (_context.Contact?.Any(e => e.Email == id)).GetValueOrDefault();
        }
        
        public SelectList Categories()
        {
            return new SelectList(_context.Categories.ToList(), "Category", "Category");
        }
    }
}
