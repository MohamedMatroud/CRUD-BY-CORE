using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudMind;
using CrudMind.Data;

namespace CrudMind.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerDbContext _context;

        public CustomersController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(
                                string sortOrder,
                                string currentFilter,
                                string searchString,
                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var customers = from s in _context.Customers
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerLastName.Contains(searchString)
                                       || s.CustomerFirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.CustomerLastName);
                    break;
                case "Date":
                    customers = customers.OrderBy(s => s.CustomerDob);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(s => s.CustomerDob);
                    break;
                default:
                    customers = customers.OrderBy(s => s.CustomerLastName);
                    break;
            }
            //return View(await _context.Customers.ToListAsync());
            //return View(await customers.AsNoTracking().ToListAsync());
            int pageSize = 3;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var customer = await _context.Customers
        .Include(s => s.Addresses)

        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerFirstName,CustomerLastName,CustomerGender,CustomerDob,CustomerEmail")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerFirstName,CustomerLastName,CustomerGender,CustomerDob,CustomerEmail")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int  id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);

            var address = _context.Addresses
                .Where(d => d.CustomerId == id)
                .SingleOrDefault();
            if (address != null)
            {
                address.CustomerId = null;
            }
            await _context.SaveChangesAsync();

          

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
