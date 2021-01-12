using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models.LibraryViewModels;
namespace ProiectFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProgramContext _context;
        public HomeController(ProgramContext context)
        {
            _context = context;
        }
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> MostWanted()
        {
            IQueryable<ClientsGroup> data =
           from order in _context.Appointments
            group order by order.Training.Name into clientGroup
            select new ClientsGroup()
            {
                TrainingName = clientGroup.Key,
                ClientCount = clientGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
        public IActionResult Chat()
        {
            return View();
        }
    }
}
