using CrudMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudMind;
using CrudMind.Models.CustomerViewModels;
using Microsoft.EntityFrameworkCore;
using CrudMind.Data;

namespace CrudMind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerDbContext _context;

        public HomeController(ILogger<HomeController> logger, CustomerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<AdressGroup> data =
                from customer in _context.Customers
                group customer by customer.CustomerDob into dateGroup
                select new AdressGroup()
                {
                    CustomerDOB = dateGroup.Key,
                    CustomerCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
