using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalendarMVC.Models;

namespace CalendarMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DateTime currDate;
        public CalendarViewModel calendarView;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Calendar()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            return Calendar(year,month);
        } 

        [Route("{month:int}-{year:int}")]
        public IActionResult Calendar(int year, int month)
        {

            CalendarViewModel viewModel = new CalendarViewModel();
            viewModel.MyYear=year;
            viewModel.MyMonth=month;
          
            return View(viewModel);
        }



     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
